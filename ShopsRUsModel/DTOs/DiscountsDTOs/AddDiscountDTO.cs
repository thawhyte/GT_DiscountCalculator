using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUsModel.DTOs.DiscountsDTOs
{
    public class AddDiscountDTO
    {
        [Required]
        public string DiscountType { get; set; }
        [Required]
        public decimal Percentage { get; set; }
    }
}
