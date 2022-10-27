using Microsoft.EntityFrameworkCore;
using ShopsRUsData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUsData.Configuration
{
    public static class CustomerConfiguration
    {
        public static ModelBuilder Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().Property(c => c.FirstName).IsRequired(true).HasMaxLength(AppConsts.MinTableLenght); //.HasColumnName("first_name");
            modelBuilder.Entity<Customer>().Property(c => c.LastName).IsRequired(true).HasMaxLength(AppConsts.MinTableLenght);
            modelBuilder.Entity<Customer>().Property(c => c.PhoneNo).IsRequired(true).HasMaxLength(50);
            modelBuilder.Entity<Customer>().Property(c => c.Email).IsRequired(true).HasMaxLength(AppConsts.MinTableLenght);
            modelBuilder.Entity<Customer>().Property(c => c.Address).IsRequired(true).HasMaxLength(AppConsts.MinTableLenght);
            modelBuilder.Entity<Customer>().Property(c => c.CompanyName).IsRequired(true).HasMaxLength(AppConsts.MaxTableLenght);
            modelBuilder.Entity<Customer>().Property(c => c.Gender).IsRequired(true).HasMaxLength(AppConsts.MinTableLenght);

            modelBuilder.Entity<Customer>().HasIndex(c => c.PhoneNo).IsUnique();
            modelBuilder.Entity<Customer>().HasIndex(c => c.Email).IsUnique();

            modelBuilder.Entity<Customer>()
              .HasKey(x => new { x.Id });


            return modelBuilder;
        }
    }
}
