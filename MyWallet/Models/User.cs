#nullable disable

namespace MyWallet.Models;

public partial class User
{
    public int id { get; set; }

    public string password { get; set; }

    public string username { get; set; }

    public virtual ICollection<Expense> Expenses { get; set; } = new List<Expense>();

    public virtual ICollection<Income> Incomes { get; set; } = new List<Income>();
}