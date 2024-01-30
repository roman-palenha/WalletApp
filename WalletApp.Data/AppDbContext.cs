using Microsoft.EntityFrameworkCore;
using WalletApp.Data.Entities;

namespace WalletApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {
                
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<CardBalance> CardBalances { get; set; }
    }
}
