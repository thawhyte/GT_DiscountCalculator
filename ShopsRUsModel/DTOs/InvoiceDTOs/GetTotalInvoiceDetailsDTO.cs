using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUsModel.DTOs.InvoiceDTOs
{
    public class GetTotalInvoiceDetailsDTO
    {
        public ItemDetails itemDetails { get; set; }
        public CustomerDetails customerDetails { get; set; }
        public DateTime TransactionDate { get; set; }
        public string ReferenceNo { get; set; }
        public int InvoiceNo { get; set; }
        public decimal SubTotalAmount { get; set; }
        public decimal Disount { get; set; }
        public string DiscountType { get; set; }
        public decimal TotalBalanceAmount { get; set; }
        public string AmountInWords { get; set; }

        public GetTotalInvoiceDetailsDTO()
        {
            itemDetails = new ItemDetails();
            customerDetails = new CustomerDetails();
        }
    }

    public class ItemDetails
    {
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total { get; set; }
    }

    public class CustomerDetails
    {
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string CompanyName { get; set; }

    }
}
