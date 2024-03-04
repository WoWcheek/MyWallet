using MyWallet.Models;

namespace MyWallet.Controllers
{
    public class UserController
    {
        private walletContext context;

        public UserController()
        {
            context = new walletContext();
        }

        public User? Register(string name, string password)
        {
            try
            {
                User newUser = new User() { name = name, password = password };
                context.Users.Add(newUser);
                context.SaveChanges();
                return newUser;
            }
            catch
            {
                return null;
            }
        }

        public User? Login(string name, string password)
        {
            try
            {
                User? loggedInUser = context.Users.ToList().FirstOrDefault(user => user.name == name && user.password == password);
                return loggedInUser;
            }
            catch
            {
                return null;
            }
        }
    }
}
