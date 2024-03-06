using MyWallet.Controllers;
using MyWallet.Models;

namespace MyWallet.Views.UserControls
{
    public partial class ItemUC : UserControl
    {
        private IncomeController? incomeController;
        private ExpenseController? expenseController;

        private int id;

        public ItemUC()
        {
            InitializeComponent();
        }

        public ItemUC(Income income, IncomeController controller, bool showDelete=true) : this()
        {
            incomeController = controller;

            id = income.id;
            categoryLbl.Text = income.category.category_name;
            amountLbl.Text = Math.Round(income.amount).ToString() + " UAH";
            descriptionLbl.Text = income.description;
            dateLbl.Text = income.received_at.ToShortDateString();

            deleteBtn.Visible = showDelete;
        }

        public ItemUC(Expense expense, ExpenseController controller, bool showDelete=true) : this()
        {
            expenseController = controller;

            id = expense.id;
            categoryLbl.Text = expense.category.category_name;
            amountLbl.Text = Math.Round(expense.amount).ToString() + " UAH";
            descriptionLbl.Text = expense.description;
            dateLbl.Text = expense.received_at.ToShortDateString();

            deleteBtn.Visible = showDelete;
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (incomeController is not null)
            {
                if (incomeController.DeleteIncomeById(id))
                    Dispose();
            }
            else if (expenseController is not null)
            {
                if (expenseController.DeleteExpenseById(id))
                    Dispose();
            }
        }
    }
}
