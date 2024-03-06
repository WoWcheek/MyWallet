using Microsoft.EntityFrameworkCore;
using MyWallet.Models;

namespace MyWallet.Controllers
{
    public class IncomeController
    {
        private WalletContext context;

        public IncomeController()
        {
            context = new WalletContext();
        }

        public List<IncomesCategory> GetIncomesCategories() => context.IncomesCategories.ToList();

        public List<IncomesCategory> GetIncomesCategoriesByUser(User user)
        {
            List<IncomesCategory> allCategories = context.IncomesCategories.ToList();
            List<IncomesCategory> categoriesForUser = new List<IncomesCategory>();
            foreach (var category in allCategories)
            {
                IncomesCategory tmp = new IncomesCategory() { id = category.id, category_name = category.category_name };
                category.Incomes.Where(x => x.user_id == user.id).ToList().ForEach(tmp.Incomes.Add);
                if (tmp.Incomes.Count > 0)
                    categoriesForUser.Add(tmp);
            }
            return categoriesForUser;
        }

        public List<Income> GetUserIncomes(User user) => 
            context.Incomes.ToList().Where(x => x.user_id == user.id).ToList();

        public IncomesCategory? GetCategoryById(int id) => 
            context.IncomesCategories.ToList().FirstOrDefault(x => x.id == id);

        public IncomesCategory? GetCategoryByName(string categoryName) => 
            context.IncomesCategories.ToList().FirstOrDefault(x => x.category_name == categoryName);

        public bool AddIncome(Income newIncome)
        {
            try
            {
                context.Add(newIncome);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteIncomeById(int id)
        {
            var toDelete = context.Incomes.FirstOrDefault(x => x.id == id);
            try
            {
                context.Incomes.Remove(toDelete);
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
