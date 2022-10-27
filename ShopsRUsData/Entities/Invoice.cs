using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUsData.Entities
{
    [Table("tbl_invoice")]
    public class Invoice : BaseEntity<int>
    {
        public string ReferenceNo { get; set; }
        public int  InvoiceNo { get; set; }
        public string ItemID { get; set; }
        public int Quantity { get; set; }
        public decimal TotalItemAmount { get; set; }
        public decimal SubtotalAmount { get; set; }
        public decimal TotalBalanceAmount { get; set; }
        public string TotalBalanceInWords { get; set; }
        public string Currency { get; set; }
        public int ClientID { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Initiator { get; set; }
        public int? DiscountId { get; set; }
        public bool IsDeleted { get; set; }

    }
}
