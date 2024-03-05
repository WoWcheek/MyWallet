using MyWallet.Controllers;
using MyWallet.Models;

namespace MyWallet.Views.UserControls
{
    public partial class ItemUC : UserControl
    {
        bool isIncome;
        private int id;

        public ItemUC()
        {
            InitializeComponent();
        }

        public ItemUC(Income income) : this()
        {
            isIncome = true;
            id = income.id;
            categoryLbl.Text = income.category.category_name;
            amountLbl.Text = Math.Round(income.amount).ToString() + " UAH";
            descriptionLbl.Text = income.description;
            dateLbl.Text = income.received_at.ToShortDateString();
        }

        public ItemUC(Expense expense) : this()
        {
            isIncome = false;
            id = expense.id;
            categoryLbl.Text = expense.category.category_name;
            amountLbl.Text = Math.Round(expense.amount).ToString() + " UAH";
            descriptionLbl.Text = expense.description;
            dateLbl.Text = expense.received_at.ToShortDateString();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (isIncome)
            {
                IncomeController controller = new IncomeController();
                if (controller.DeleteIncomeById(id))
                    Dispose();
            }
            else
            {
                ExpenseController controller = new ExpenseController();
                if (controller.DeleteExpenseById(id))
                    Dispose();
            }
        }
    }
}
