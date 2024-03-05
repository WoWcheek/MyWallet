#nullable disable

namespace MyWallet.Models;

public partial class Income
{
    public int id { get; set; }

    public int user_id { get; set; }

    public string description { get; set; }

    public int category_id { get; set; }

    public DateTime received_at { get; set; }

    public decimal amount { get; set; }

    public virtual IncomesCategory category { get; set; }

    public virtual User user { get; set; }
}