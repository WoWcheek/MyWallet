using MyWallet.Models;
using MyWallet.Views;

namespace MyWallet
{
    public partial class MainForm : Form
    {
        private User? ActiveUser { get; set; }

        public MainForm()
        {
            InitializeComponent();
            ActiveUser = null;
            mainPanel.Visible = false;
            GetAuthUser();
            mainPanel.Visible = true;
        }

        private void GetAuthUser()
        {
            do
            {
                AuthForm authForm = new AuthForm();
                authForm.ShowDialog();
                ActiveUser = authForm.ActiveUser;
            } while (ActiveUser is null);
        }
    }
}
