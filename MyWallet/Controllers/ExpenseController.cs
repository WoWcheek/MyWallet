using MyWallet.Models;

namespace MyWallet.Controllers
{
    public class ExpenseController
    {
        private WalletContext context;

        public ExpenseController()
        {
            context = new WalletContext();
        }

        public List<Expense> GetUserExpenses(User user) => context.Expenses.ToList().Where(x => x.user_id == user.id).ToList();

        public ExpensesCategory? GetCategoryById(int id) => context.ExpensesCategories.ToList().FirstOrDefault(x => x.id == id);

        public bool DeleteExpenseById(int id)
        {
            var toDelete = context.Expenses.FirstOrDefault(x => x.id == id);
            try
            {
                context.Expenses.Remove(toDelete);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}