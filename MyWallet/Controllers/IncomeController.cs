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

        public List<Income> GetUserIncomes(User user) => context.Incomes.ToList().Where(x => x.user_id == user.id).ToList();

        public IncomesCategory? GetCategoryById(int id) => context.IncomesCategories.ToList().FirstOrDefault(x => x.id == id);

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
