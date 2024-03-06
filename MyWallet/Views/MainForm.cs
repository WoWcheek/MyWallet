using MindFusion.Charting;
using MyWallet.Controllers;
using MyWallet.Models;
using MyWallet.Views;
using MyWallet.Views.UserControls;

namespace MyWallet
{
    public enum AppState { Home, Income, Expense }

    public partial class MainForm : Form
    {
        private IncomeController incomeController;
        private ExpenseController expenseController;
        private List<Color> colors;

        private User? ActiveUser { get; set; }

        private AppState _state;
        private AppState State
        {
            get => _state;

            set
            {
                switch (value)
                {
                    case AppState.Home:
                        mainLineChart.Visible = listPanel.Visible = false;
                        incomesPC.Visible = expensesPC.Visible = true;
                        RemoveTopItems();
                        ReloadHomeInfo();
                        break;

                    case AppState.Income:
                        mainLineChart.Visible = listPanel.Visible = true;
                        incomesPC.Visible = expensesPC.Visible = false;
                        RemoveTopItems();
                        break;

                    case AppState.Expense:
                        mainLineChart.Visible = listPanel.Visible = true;
                        incomesPC.Visible = expensesPC.Visible = false;
                        RemoveTopItems();
                        break;

                    default:
                        throw new NotImplementedException();
                }
                _state = value;
            }
        }

        public MainForm()
        {
            InitializeComponent();
            mainLineChart.ShowLegend = incomesPC.ShowLegend = expensesPC.ShowLegend = false;
            incomesPC.Theme.DataLabelsFontSize = 10;
            expensesPC.Theme.DataLabelsFontSize = 10;
            InitColor();

            ExecuteWithHideMainPanel(GetAuthUser);
            usernameLbl.Text = ActiveUser?.username;

            incomeController = new IncomeController();
            expenseController = new ExpenseController();

            var incomes = incomeController.GetUserIncomes(ActiveUser);
            var expenses = expenseController.GetUserExpenses(ActiveUser);

            State = AppState.Home;
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
            State = AppState.Home;
        }

        private void ReloadHomeInfo(object? sender = null, EventArgs? e = null)
        {
            SetPieCharts();
            SetStatsItems();
        }

        private void incomeBtn_Click(object sender, EventArgs e)
        {
            if (ActiveUser is null)
                return;

            State = AppState.Income;

            List<Income> userIncomes = incomeController.GetUserIncomes(ActiveUser).OrderBy(x => x.received_at).ToList();
            userIncomes = ListWithCategories(userIncomes);
            List<Pair<DateTime, decimal>> userIncomesDatesValues = userIncomes
                                                                    .GroupBy(x => x.received_at.Date)
                                                                    .Select(group =>
                                                                            new Pair<DateTime, decimal>
                                                                            (group.Key, group.Sum(income => income.amount)))
                                                                    .OrderBy(x => x.First)
                                                                    .ToList();

            DateTime minDate = userIncomes.Count > 0 ?
                                userIncomes.MinBy(x => x.received_at).received_at :
                                DateTime.Now;
            DateTime maxDate = userIncomes.Count > 0 ?
                                userIncomes.MaxBy(x => x.received_at).received_at :
                                DateTime.Now;
            List<DateTime> dates = DateBounds(minDate, maxDate);

            List<double> userIncomesValues = ExpandValuesForDates(userIncomesDatesValues, dates);

            DateTimeSeries incomeSeries = new DateTimeSeries(dates, userIncomesValues, minDate, maxDate);
            incomeSeries.CustomDateTimeFormat = "dd/MM";

            SetChart(incomeSeries, "Income");
            SetItemsList(userIncomes);
        }

        private void expensesBtn_Click(object sender, EventArgs e)
        {
            if (ActiveUser is null)
                return;

            State = AppState.Expense;

            List<Expense> userExpenses = expenseController.GetUserExpenses(ActiveUser).OrderBy(x => x.received_at).ToList();
            userExpenses = ListWithCategories(userExpenses);
            List<Pair<DateTime, decimal>> userExpensesDatesValues = userExpenses
                                                                     .GroupBy(x => x.received_at.Date)
                                                                     .Select(group =>
                                                                             new Pair<DateTime, decimal>
                                                                             (group.Key, group.Sum(income => income.amount)))
                                                                     .OrderBy(x => x.First)
                                                                     .ToList();

            DateTime minDate = userExpenses.Count > 0 ?
                                userExpenses.MinBy(x => x.received_at).received_at :
                                DateTime.Now;
            DateTime maxDate = userExpenses.Count > 0 ?
                                userExpenses.MaxBy(x => x.received_at).received_at :
                                DateTime.Now;
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

        private void SetPieCharts()
        {
            List<IncomesCategory> incomesByCategories = incomeController.GetIncomesCategoriesByUser(ActiveUser);
            Dictionary<string, double> incomesDict = new Dictionary<string, double>();
            foreach (var category in incomesByCategories)
            {
                if (category.Incomes.Count == 0)
                    continue;

                incomesDict.Add(category.category_name, 0);
                foreach (var income in category.Incomes)
                {
                    incomesDict[category.category_name] += (double)income.amount;
                }
            }

            List<ExpensesCategory> expensesByCategories = expenseController.GetExpensesCategoriesByUser(ActiveUser);
            Dictionary<string, double> expensesDict = new Dictionary<string, double>();
            foreach (var category in expensesByCategories)
            {
                if (category.Expenses.Count == 0)
                    continue;

                expensesDict.Add(category.category_name, 0);
                foreach (var expense in category.Expenses)
                {
                    expensesDict[category.category_name] += (double)expense.amount;
                }
            }

            List<string> incomesInnerLabels = incomesDict.Values.Select(x => x.ToString()).ToList();
            List<string> expensesInnerLabels = expensesDict.Values.Select(x => x.ToString()).ToList();

            incomesPC.Series = new PieSeries(incomesDict.Values.ToList(), incomesInnerLabels, incomesDict.Keys.ToList());
            expensesPC.Series = new PieSeries(expensesDict.Values.ToList(), expensesInnerLabels, expensesDict.Keys.ToList());

            SetPieChartsStyles();
        }

        private void RemoveTopItems()
        {
            mainPanel.Controls.RemoveByKey("topIncomeItem");
            mainPanel.Controls.RemoveByKey("topExpenseItem");
            mainPanel.Controls.RemoveByKey("summaryItem");
        }

        private void SetStatsItems()
        {
            SetTopItems();

            decimal totalIncome = incomeController.GetUserIncomes(ActiveUser).Sum(x => x.amount);
            decimal totalExpense = expenseController.GetUserExpenses(ActiveUser).Sum(x => x.amount);

            mainPanel.Controls.Add(new SummaryUC(totalIncome, totalExpense)
            {
                Name = "summaryItem",
                Location = new Point(400, 550)
            });
        }

        private void SetTopItems()
        {
            if (ActiveUser is null)
                return;

            Income? topIncome = incomeController.GetUserIncomes(ActiveUser).MaxBy(x => x.amount);
            Expense? topExpense = expenseController.GetUserExpenses(ActiveUser).MaxBy(x => x.amount);

            if (topIncome is not null)
                mainPanel.Controls.Add(new ItemUC(topIncome, incomeController, false)
                {
                    Name = "topIncomeItem",
                    Location = new Point(400, 400)
                });
            if (topExpense is not null)
                mainPanel.Controls.Add(new ItemUC(topExpense, expenseController, false)
                {
                    Name = "topExpenseItem",
                    Location = new Point(950, 400)
                });
        }

        private void SetPieChartsStyles()
        {
            int incomesElemCount = incomesPC.Series.Size;
            int expensesElemCount = expensesPC.Series.Size;

            List<MindFusion.Drawing.Brush> brushesIncome = new List<MindFusion.Drawing.Brush>();
            for (int i = 0; i < incomesElemCount; i++)
            {
                brushesIncome.Add(new MindFusion.Drawing.SolidBrush(colors[i]));
            }

            List<MindFusion.Drawing.Brush> brushesExpense = new List<MindFusion.Drawing.Brush>();
            for (int i = 0; i < expensesElemCount; i++)
            {
                brushesExpense.Add(new MindFusion.Drawing.SolidBrush(colors[i]));
            }

            incomesPC.Plot.SeriesStyle = new PerElementSeriesStyle()
            {
                Fills = new List<List<MindFusion.Drawing.Brush>>() { brushesIncome }
            };
            expensesPC.Plot.SeriesStyle = new PerElementSeriesStyle()
            {
                Fills = new List<List<MindFusion.Drawing.Brush>>() { brushesExpense }
            };
        }

        private void InitColor()
        {
            colors = new List<Color>()
            {
                Color.FromArgb(0, 114, 178),     // Blue
                Color.FromArgb(230, 159, 0),     // Orange
                Color.FromArgb(86, 180, 233),    // Sky Blue
                Color.FromArgb(0, 158, 115),     // Green
                Color.FromArgb(240, 228, 66),    // Yellow
                Color.FromArgb(213, 94, 0),      // Orange-Red
                Color.FromArgb(204, 121, 167),   // Pink
                Color.FromArgb(240, 228, 66),    // Yellow
                Color.FromArgb(0, 114, 178),     // Blue
                Color.FromArgb(86, 180, 233),    // Sky Blue
                Color.FromArgb(213, 94, 0),      // Orange-Red
                Color.FromArgb(0, 158, 115),     // Green
                Color.FromArgb(204, 121, 167),   // Pink
                Color.FromArgb(240, 228, 66),    // Yellow
                Color.FromArgb(227, 119, 194)    // Purple
            };
        }

        private void SetItemsList(List<Income> incomes)
        {
            const int xPadding = 10;
            const int yPadding = 5;

            listPanel.Controls.Clear();
            for (int i = 0; i < incomes.Count; i++)
            {
                ItemUC incomeItem = new ItemUC(incomes[i], incomeController) { Name = $"item{i}" };
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
            for (int i = 0; i < expenses.Count; i++)
            {
                ItemUC expenseItem = new ItemUC(expenses[i], expenseController) { Name = $"item{i}" };
                expenseItem.Disposed += ResetStatistics;
                listPanel.Controls.Add(expenseItem);
                listPanel.Controls[$"item{i}"].Left = xPadding;
                listPanel.Controls[$"item{i}"].Top = yPadding + i * (expenseItem.Height + yPadding);
            }
        }

        private void ResetStatistics(object? sender, EventArgs? e) => State = State;

        private void logOutLbl_Click(object sender, EventArgs e)
        {
            ExecuteWithHideMainPanel(GetAuthUser);
            usernameLbl.Text = ActiveUser?.username;

            var incomes = incomeController.GetUserIncomes(ActiveUser);
            var expenses = expenseController.GetUserExpenses(ActiveUser);

            State = AppState.Home;
        }

        private void newIncomeBtn_Click(object sender, EventArgs e)
        {
            if (ActiveUser is null)
                return;

            AddForm addIncomeForm = new AddForm(incomeController, ActiveUser.id);
            addIncomeForm.Disposed += ResetStatistics;
            addIncomeForm.ShowDialog();
        }

        private void newExpenseBtn_Click(object sender, EventArgs e)
        {
            if (ActiveUser is null)
                return;

            AddForm addExpenseForm = new AddForm(expenseController, ActiveUser.id);
            addExpenseForm.Disposed += ResetStatistics;
            addExpenseForm.ShowDialog();
        }
    }
}
