using Microsoft.EntityFrameworkCore;
using ShopsRUsData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUsData.Configuration
{
    public class AssetItemConfiguration
    {
        public static ModelBuilder Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssetItems>().Property(c => c.ItemCode).IsRequired(true).HasMaxLength(AppConsts.MinTableLenght); //.HasColumnName("first_name");
            modelBuilder.Entity<AssetItems>().Property(c => c.ItemDescription).IsRequired(true).HasMaxLength(AppConsts.MaxTableLenght);
            modelBuilder.Entity<AssetItems>().Property(c => c.MarketIntelligencePrice).IsRequired(true);
            modelBuilder.Entity<AssetItems>().Property(c => c.AssetType).IsRequired(true);
            
            modelBuilder.Entity<AssetItems>().HasIndex(c => c.ItemCode).IsUnique();

            modelBuilder.Entity<AssetItems>()
              .HasKey(x => new { x.Id });

            return modelBuilder;
        }
    }
}
