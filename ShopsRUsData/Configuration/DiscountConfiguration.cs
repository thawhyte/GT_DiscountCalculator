using Microsoft.EntityFrameworkCore;
using ShopsRUsData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUsData.Configuration
{
    public class DiscountConfiguration
    {

        public static ModelBuilder Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Discounts>().Property(c => c.DiscountType).IsRequired(true).HasMaxLength(AppConsts.MinTableLenght); //.HasColumnName("first_name");
            modelBuilder.Entity<Discounts>().Property(c => c.Percentage).IsRequired(true);
            modelBuilder.Entity<Discounts>().Property(c => c.Create_date).IsRequired(true);
            modelBuilder.Entity<Discounts>().Property(c => c.Created_By).IsRequired(true);


            modelBuilder.Entity<Discounts>()
                  .HasKey(x => new { x.Id });

                return modelBuilder;
        }
    }
}
