using MindFusion.Charting;
using MyWallet.Controllers;
using MyWallet.Models;
using MyWallet.Views;
using MyWallet.Views.UserControls;

namespace MyWallet
{
    public partial class MainForm : Form
    {
        private IncomeController incomeController;
        private ExpenseController expenseController;
        private User? ActiveUser { get; set; }

        public MainForm()
        {
            InitializeComponent();
            mainLineChart.ShowLegend = false;

            incomeController = new IncomeController();
            expenseController = new ExpenseController();

            ExecuteWithHideMainPanel(GetAuthUser);
            usernameLbl.Text = ActiveUser?.username;

            homeBtn.PerformClick();
        }

        private void ExecuteWithHideMainPanel(Action action)
        {
            mainPanel.Visible = false;
            action();
            mainPanel.Visible = true;
        }

        private void GetAuthUser()
        {
            do
            {
                AuthForm authForm = new AuthForm();
                authForm.ShowDialog();
                ActiveUser = authForm.ActiveUser;
                if (authForm.AuthExited)
                {
                    ActiveUser = new User();
                    Dispose();
                }
            } while (ActiveUser is null);
        }

        private void homeBtn_Click(object sender, EventArgs e)
        {
        }

        private void incomeBtn_Click(object sender, EventArgs e)
        {
            if (ActiveUser is null)
                return;

            List<Income> userIncomes = incomeController.GetUserIncomes(ActiveUser).OrderBy(x => x.received_at).ToList();
            userIncomes = ListWithCategories(userIncomes);
            List<Pair<DateTime, decimal>> userIncomesDatesValues = userIncomes
                                                                    .GroupBy(x => x.received_at.Date)
                                                                    .Select(group =>
                                                                            new Pair<DateTime, decimal>
                                                                            (group.Key, group.Sum(income => income.amount)))
                                                                    .OrderBy(x => x.First)
                                                                    .ToList();
            DateTime minDate = userIncomes.MinBy(x => x.received_at).received_at;
            DateTime maxDate = userIncomes.MaxBy(x => x.received_at).received_at;
            List<DateTime> dates = DateBounds(minDate, maxDate);

            List<double> userIncomesValues = ExpandValuesForDates(userIncomesDatesValues, dates);

            DateTimeSeries incomeSeries = new DateTimeSeries(dates, userIncomesValues, minDate, maxDate);
            incomeSeries.CustomDateTimeFormat = "dd/MM";

            SetChart(incomeSeries, "Income");
            SetItemsList(userIncomes);
        }

        private void expensesBtn_Click(object sender, EventArgs e)
        {
            List<Expense> userExpenses = expenseController.GetUserExpenses(ActiveUser).OrderBy(x => x.received_at).ToList();
            userExpenses = ListWithCategories(userExpenses);
            List<Pair<DateTime, decimal>> userExpensesDatesValues = userExpenses
                                                                     .GroupBy(x => x.received_at.Date)
                                                                     .Select(group =>
                                                                             new Pair<DateTime, decimal>
                                                                             (group.Key, group.Sum(income => income.amount)))
                                                                     .OrderBy(x => x.First)
                                                                     .ToList();
            DateTime expenseMinDate = userExpenses.ToList().MinBy(x => x.received_at).received_at;
            DateTime expenseMaxDate = userExpenses.ToList().MaxBy(x => x.received_at).received_at;

            DateTime minDate = userExpenses.MinBy(x => x.received_at).received_at;
            DateTime maxDate = userExpenses.MaxBy(x => x.received_at).received_at;
            List<DateTime> dates = DateBounds(minDate, maxDate);

            List<double> userExpensesValues = ExpandValuesForDates(userExpensesDatesValues, dates);

            DateTimeSeries expenseSeries = new DateTimeSeries(dates, userExpensesValues, minDate, maxDate);
            expenseSeries.CustomDateTimeFormat = "dd/MM";

            SetChart(expenseSeries, "Expense");
            SetItemsList(userExpenses);
        }

        private List<DateTime> DateBounds(DateTime startDateTime, DateTime endDateTime)
        {
            List<DateTime> dateBounds = new List<DateTime>();
            for (; startDateTime <= endDateTime; startDateTime = startDateTime.AddDays(1))
                dateBounds.Add(startDateTime.Date);
            return dateBounds;
        }

        private List<double> ExpandValuesForDates(List<Pair<DateTime, decimal>> datesValues, List<DateTime> dates)
        {
            List<double> expandedList = new List<double>();
            foreach (DateTime date in dates)
            {
                int index = datesValues.FindIndex(x => x.First == date);
                if (index == -1)
                    expandedList.Add(0);
                else
                    expandedList.Add((double)datesValues[index].Second);
            }
            return expandedList;
        }

        private List<Income> ListWithCategories(List<Income> incomes)
        {
            List<Income> incomesWithCategories = new List<Income>();
            foreach (Income income in incomes)
            {
                Income incomeWithCat = income;
                incomeWithCat.category = incomeController.GetCategoryById(income.category_id);
                incomesWithCategories.Add(incomeWithCat);
            }
            return incomesWithCategories;
        }

        private List<Expense> ListWithCategories(List<Expense> expenses)
        {
            List<Expense> expenseWithCategories = new List<Expense>();
            foreach (Expense expense in expenses)
            {
                Expense expenseWithCat = expense;
                expenseWithCat.category = expenseController.GetCategoryById(expense.category_id);
                expenseWithCategories.Add(expenseWithCat);
            }
            return expenseWithCategories;
        }

        private void SetChart(DateTimeSeries series, string yAxisTitle, string xAxisTitle = "Date")
        {
            mainLineChart.XAxis.Title = xAxisTitle;
            mainLineChart.YAxis.Title = yAxisTitle;
            mainLineChart.Series.Clear();
            mainLineChart.Series.Add(series);
        }

        private void SetItemsList(List<Income> incomes)
        {
            const int xPadding = 10;
            const int yPadding = 5;

            listPanel.Controls.Clear();
            listPanel.Name = "Incomes";
            for (int i = 0; i < incomes.Count; i++)
            {
                ItemUC incomeItem = new ItemUC(incomes[i]) { Name = $"item{i}" };
                incomeItem.Disposed += ResetStatistics;
                listPanel.Controls.Add(incomeItem);
                listPanel.Controls[$"item{i}"].Left = xPadding;
                listPanel.Controls[$"item{i}"].Top = yPadding + i * (incomeItem.Height + yPadding);
            }
        }

        private void SetItemsList(List<Expense> expenses)
        {
            const int xPadding = 10;
            const int yPadding = 5;

            listPanel.Controls.Clear();
            listPanel.Name = "Expenses";
            for (int i = 0; i < expenses.Count; i++)
            {
                ItemUC expenseItem = new ItemUC(expenses[i]) { Name = $"item{i}" };
                expenseItem.Disposed += ResetStatistics;
                listPanel.Controls.Add(expenseItem);
                listPanel.Controls[$"item{i}"].Left = xPadding;
                listPanel.Controls[$"item{i}"].Top = yPadding + i * (expenseItem.Height + yPadding);
            }
        }

        private void ResetStatistics(object sender, EventArgs e)
        {
            if (listPanel.Name == "Incomes")
                incomeBtn.PerformClick();
            else if (listPanel.Name == "Expenses")
                expensesBtn.PerformClick();
        }
    }
}
