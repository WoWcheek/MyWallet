#nullable disable

namespace MyWallet.Models;

public partial class IncomesCategory
{
    public int id { get; set; }

    public string category_name { get; set; }

    public virtual ICollection<Income> Incomes { get; set; } = new List<Income>();
}