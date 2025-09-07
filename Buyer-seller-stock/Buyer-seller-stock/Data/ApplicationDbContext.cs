using Buyer_seller_stock.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace Buyer_seller_stock.Data
{
    public class ApplicationDbContext: DbContext
    {
    public ApplicationDbContext(DbContextOptions options):base(options) { 
        }
        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<Buyer> Buyer { get; set; }
        public DbSet<Seller> Seller { get; set; }   
        public DbSet<User> User { get; set; }
        public DbSet<Stock> Stock { get; set; }
    }
}
