using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopBridge.Core.Entity.Inventory;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopBridge.Core.Entity.Configuration
{
    /// <summary>
    /// Configure the Entity Model for Data base table
    /// </summary>
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product", "Inventory");
            builder.HasIndex(new string[] { "ProductName", "SKUCode" });
            builder.Property(x => x.ProductName).HasColumnType("varchar").HasMaxLength(250).IsRequired();
            builder.Property(x => x.SKUCode).HasColumnType("Varchar").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Price).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.Description).HasColumnType("varchar").HasMaxLength(500);
            builder.Property(x => x.CreatedBy).HasDefaultValue(1);
            builder.Property(x => x.CreatedDate).HasDefaultValue(DateTime.Now.Date);
         
        }
    }
}
