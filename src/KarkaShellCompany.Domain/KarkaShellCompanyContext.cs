using KarkaShellCompany.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace KarkaShellCompany.Domain;

public class KarkaShellCompanyContext : DbContext
{
    public KarkaShellCompanyContext(DbContextOptions<KarkaShellCompanyContext> options)
        : base(options)
    {
    }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<Guild> Guilds { get; set; }
    public DbSet<Item> Items { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
