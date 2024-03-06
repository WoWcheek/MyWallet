using MyWallet.Models;
using System.Collections.Generic;

namespace MyWallet.Controllers
{
    public class ExpenseController
    {
        private WalletContext context;

        public ExpenseController()
        {
            context = new WalletContext();
        }

        public List<ExpensesCategory> GetExpensesCategories() => context.ExpensesCategories.ToList();

        public List<ExpensesCategory> GetExpensesCategoriesByUser(User user)
        {
            List<ExpensesCategory> allCategories = context.ExpensesCategories.ToList();
            List<ExpensesCategory> categoriesForUser = new List<ExpensesCategory>();
            foreach (var category in allCategories)
            {
                ExpensesCategory tmp = new ExpensesCategory() { id = category.id, category_name = category.category_name };
                category.Expenses.Where(x => x.user_id == user.id).ToList().ForEach(tmp.Expenses.Add);
                if (tmp.Expenses.Count > 0)
                    categoriesForUser.Add(tmp);
            }
            return categoriesForUser;
        }

        public List<Expense> GetUserExpenses(User user) =>
            context.Expenses.ToList().Where(x => x.user_id == user.id).ToList();

        public ExpensesCategory? GetCategoryById(int id) =>
            context.ExpensesCategories.ToList().FirstOrDefault(x => x.id == id);

        public ExpensesCategory? GetCategoryByName(string categoryName) =>
            context.ExpensesCategories.ToList().FirstOrDefault(x => x.category_name == categoryName);

        public bool AddExpense(Expense newExpense)
        {
            try
            {
                context.Add(newExpense);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

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