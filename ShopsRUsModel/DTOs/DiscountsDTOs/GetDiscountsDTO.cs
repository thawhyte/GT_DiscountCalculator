using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUsModel.DTOs.DiscountsDTOs
{
    public class GetDiscountsDTO
    {
        public string DiscountType { get; set; } 
        public decimal Percentage { get; set; }
        public string IsDefault { get; set; }
        public DateTime Create_date { get; set; }
        public string Created_By { get; set; }
    }
}
