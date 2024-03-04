using MyWallet.Controllers;
using MyWallet.Models;

namespace MyWallet.Views
{
    public partial class AuthForm : Form
    {
        private UserController userController;
        public User? ActiveUser { get; private set; }

        public AuthForm()
        {
            InitializeComponent();
            userController = new UserController();
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            if (usernameTB.Text.Length < 5 || passwordTB.Text.Length < 5)
            {
                MessageBox.Show("Username and password should be at least 5 characters long!", "Registration status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ActiveUser = userController.Register(usernameTB.Text, passwordTB.Text);
            if (ActiveUser is User)
            {
                MessageBox.Show("User was registered successfully!", "Registration status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Dispose();
            }
            else
            {
                MessageBox.Show("Can't register user!", "Registration status", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (usernameTB.Text.Length < 5 || passwordTB.Text.Length < 5)
            {
                MessageBox.Show("Username and password should be at least 5 characters long!", "Registration status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ActiveUser = userController.Login(usernameTB.Text, passwordTB.Text);
            if (ActiveUser is User)
            {
                MessageBox.Show("You were logged in successfully!", "Login status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Dispose();
            }
            else
            {
                MessageBox.Show("Wrong password or username!", "Login status", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
