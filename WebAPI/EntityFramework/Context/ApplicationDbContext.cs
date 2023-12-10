using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.EntityFramework.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Card> Cards { get; set; }
    public DbSet<BankAccount> BankAccounts { get; set; }
    public DbSet<BankAccountType> BankAccountTypes { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<User_Sessions> UserSessions { get; set; }
}