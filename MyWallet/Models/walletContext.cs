#nullable disable
using Microsoft.EntityFrameworkCore;

namespace MyWallet.Models;

public partial class walletContext : DbContext
{
    public walletContext()
    {
    }

    public walletContext(DbContextOptions<walletContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Expense> Expenses { get; set; }

    public virtual DbSet<ExpensesCategory> ExpensesCategories { get; set; }

    public virtual DbSet<Income> Incomes { get; set; }

    public virtual DbSet<IncomesCategory> IncomesCategories { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-MRA86Q3\\SQLEXPRESS;Initial Catalog=wallet;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Expense>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__Expenses__3213E83FAA63AB8A");

            entity.Property(e => e.description)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.received_at).HasColumnType("datetime");

            entity.HasOne(d => d.category).WithMany(p => p.Expenses)
                .HasForeignKey(d => d.category_id)
                .HasConstraintName("FK__Expenses__catego__412EB0B6");

            entity.HasOne(d => d.user).WithMany(p => p.Expenses)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("FK__Expenses__user_i__403A8C7D");
        });

        modelBuilder.Entity<ExpensesCategory>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__Expenses__3213E83F11DA7179");

            entity.Property(e => e.category_name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Income>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__Incomes__3213E83FB1DBAE5B");

            entity.Property(e => e.description)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.received_at).HasColumnType("datetime");

            entity.HasOne(d => d.category).WithMany(p => p.Incomes)
                .HasForeignKey(d => d.category_id)
                .HasConstraintName("FK__Incomes__categor__3B75D760");

            entity.HasOne(d => d.user).WithMany(p => p.Incomes)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("FK__Incomes__user_id__3A81B327");
        });

        modelBuilder.Entity<IncomesCategory>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__IncomesC__3213E83F5FF683DA");

            entity.Property(e => e.category_name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__Users__3213E83FF260890A");

            entity.Property(e => e.name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.password)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}