using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<barModel> BarItems { get; set; }
    public DbSet<bar_salesModel> BarSales { get; set; }
    public DbSet<clientsModel> Clients { get; set; }
    public DbSet<computersModel> Computers { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=ex27bvw821dl;Database=computer_club");
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
