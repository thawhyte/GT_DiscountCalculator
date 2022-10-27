using Microsoft.EntityFrameworkCore;
using ShopsRUsData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUsData.Configuration
{
    public class InvoiceConfiguration
    {

        public static ModelBuilder Build(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Invoice>().Property(c => c.ClientID).IsRequired(true);//.HasMaxLength(AppConsts.MinTableLenght); //.HasColumnName("first_name");
            modelBuilder.Entity<Invoice>().Property(c => c.Initiator).IsRequired();
            modelBuilder.Entity<Invoice>().Property(c => c.Quantity).IsRequired();
            modelBuilder.Entity<Invoice>().Property(c => c.ReferenceNo).IsRequired();
            modelBuilder.Entity<Invoice>().Property(c => c.SubtotalAmount).IsRequired();
            modelBuilder.Entity<Invoice>().Property(c => c.TotalBalanceAmount).IsRequired();
            modelBuilder.Entity<Invoice>().Property(c => c.TotalItemAmount).IsRequired();
            modelBuilder.Entity<Invoice>().Property(c => c.TransactionDate).IsRequired();
            modelBuilder.Entity<Invoice>().Property(c => c.Currency).IsRequired();

            

            modelBuilder.Entity<Invoice>().HasKey(x => new { x.Id });

            return modelBuilder;
        }
    }
}
