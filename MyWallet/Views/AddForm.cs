using MyWallet.Controllers;
using MyWallet.Models;

namespace MyWallet.Views
{
    public partial class AddForm : Form
    {
        private IncomeController? incomeController;
        private ExpenseController? expenseController;

        private int userId;

        public AddForm()
        {
            InitializeComponent();
        }

        public AddForm(IncomeController controller, int userId) : this()
        {
            this.userId = userId;
            incomeController = controller;
            mainBtn.Text = $"Add Income";
            mainBtn.Click += handleAddIncome;
            SetComboBoxOptions();
        }

        public AddForm(ExpenseController controller, int userId) : this()
        {
            this.userId = userId;
            expenseController = controller;
            mainBtn.Text = $"Add Expense";
            mainBtn.Click += handleAddExpense;
            SetComboBoxOptions();
        }

        private void SetComboBoxOptions()
        {
            categoryCB.Items.Clear();

            if (incomeController is not null)
            {
                categoryCB.Items.AddRange(incomeController.GetIncomesCategories().Select(x => x.category_name).ToArray());
            }
            else if (expenseController is not null)
            {
                categoryCB.Items.AddRange(expenseController.GetExpensesCategories().Select(x => x.category_name).ToArray());
            }
        }

        private void handleAddIncome(object? sender, EventArgs e)
        {
            if (categoryCB.SelectedItem is null || amountNumeric.Value == 0)
                return;

            int? category_id = incomeController.GetCategoryByName(categoryCB.SelectedItem.ToString())?.id;
            if (category_id is null)
                return;

            Income newIncome = new Income()
            {
                user_id = userId,
                category_id = (int)category_id,
                amount = amountNumeric.Value,
                description = descriptionTB.Text,
                received_at = calendar.SelectionStart
            };

            bool added = incomeController.AddIncome(newIncome);
            if (added)
            {
                MessageBox.Show("New income was successfully added", "Addition status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Dispose();
            }
            else
            {
                MessageBox.Show("New income can not be added", "Addition status", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void handleAddExpense(object? sender, EventArgs e)
        {
            if (categoryCB.SelectedItem is null || amountNumeric.Value == 0)
                return;

            int? category_id = expenseController.GetCategoryByName(categoryCB.SelectedItem.ToString())?.id;
            if (category_id is null)
                return;

            Expense newExpense = new Expense()
            {
                user_id = userId,
                category_id = (int)category_id,
                amount = amountNumeric.Value,
                description = descriptionTB.Text,
                received_at = calendar.SelectionStart
            };

            bool added = expenseController.AddExpense(newExpense);
            if (added)
            {
                MessageBox.Show("New expense was successfully added", "Addition status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Dispose();
            }
            else
            {
                MessageBox.Show("New expense can not be added", "Addition status", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
