using MyWallet.Models;

namespace MyWallet.Controllers
{
    public class UserController
    {
        private WalletContext context;

        public UserController()
        {
            context = new WalletContext();
        }

        public User? Register(string username, string password)
        {
            try
            {
                User newUser = new User() { username = username, password = password };
                context.Users.Add(newUser);
                context.SaveChanges();
                return newUser;
            }
            catch
            {
                return null;
            }
        }

        public User? Login(string username, string password)
        {
            try
            {
                User? loggedInUser = context.Users.ToList().FirstOrDefault(user => user.username == username && user.password == password);
                return loggedInUser;
            }
            catch
            {
                return null;
            }
        }
    }
}
