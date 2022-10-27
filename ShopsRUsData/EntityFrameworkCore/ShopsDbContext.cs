using Microsoft.EntityFrameworkCore;
using ShopsRUsData.Configuration;
using ShopsRUsData.Entities;


namespace ShopsRUsData.EntityFrameworkCore
{
    public class ShopsDbContext : DbContext
    {
        public ShopsDbContext(DbContextOptions<ShopsDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> customers { get; set; }
        public DbSet<AssetItems> assetItems { get; set; }
        public DbSet<Discounts> Discounts { get; set; }
        public DbSet<Invoice> invoices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CustomerConfiguration.Build(modelBuilder);
            AssetItemConfiguration.Build(modelBuilder);
            DiscountConfiguration.Build(modelBuilder);
            InvoiceConfiguration.Build(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
