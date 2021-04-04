using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShopBridge.Core.Entity.Configuration;
using ShopBridge.Core.Entity.Inventory;

namespace ShopBridge.Core.Entity.ShopBridgeContext
{
    /// <summary>
    /// Context class for DataBase connection 
    /// The DBContext class is used to maintain the connection string and
    /// perform all the DML and DDL Statement.
    /// </summary>
    public class BridgeContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=LAPTOP-S2ID88VA\SQLEXPRESS;database=ShopBridge;trusted_connection=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }

        #region DBSetCreation

       
        public virtual DbSet<Product> Products { get; set; }

        #endregion
    }
}
