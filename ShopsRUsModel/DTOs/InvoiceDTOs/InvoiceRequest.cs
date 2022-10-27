using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUsModel.DTOs
{
    public class InvoiceRequest
    {
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public string ItemCode { get; set; }
        [Required]
        public int Quantity { get; set; }
    }



    //public class InvoiceRequest
    //{
    //    [Required]
    //    public int CustomerId { get; set; }
    //    [Required]
    //    public string ItemCode { get; set; }
    //    public int Quantity { get; set; }
    //}

    //public class ItemInvoiceData
    //{
    //    public string ItemCode { get; set; }
    //    public int Quantity { get; set; }
    //}
}
