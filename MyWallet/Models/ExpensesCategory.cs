#nullable disable

namespace MyWallet.Models;

public partial class ExpensesCategory
{
    public int id { get; set; }

    public string category_name { get; set; }

    public virtual ICollection<Expense> Expenses { get; set; } = new List<Expense>();
}