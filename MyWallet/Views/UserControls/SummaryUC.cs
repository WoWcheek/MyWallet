namespace MyWallet.Views.UserControls
{
    public partial class SummaryUC : UserControl
    {
        public SummaryUC()
        {
            InitializeComponent();
        }

        public SummaryUC(decimal totalIncome, decimal totalExpense) : this()
        {
            incomeValueLbl.Text = Math.Round(totalIncome, 2).ToString() + " UAH";
            expensevalueLbl.Text = Math.Round(totalExpense, 2).ToString() + " UAH";

            decimal balance = totalIncome - totalExpense;
            balanceValueLbl.Text = Math.Round(balance, 2).ToString() + " UAH";
            if (balance < 0)
                balanceValueLbl.ForeColor = Color.MediumVioletRed;
            else
                balanceValueLbl.ForeColor = Color.PaleGreen;
        }
    }
}
