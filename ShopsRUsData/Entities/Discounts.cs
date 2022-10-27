using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUsData.Entities
{
    [Table("tbl_discounts")]
    public class Discounts : BaseEntity<int>
    {
        [Key]
        [Required]
        public string DiscountType { get; set; } //Employee, Affiliate 
        public decimal Percentage { get; set; }
        public DateTime Create_date { get; set; }
        public string Created_By { get; set; }
        public bool IsDefault { get; set; }
        public bool isDeleted { get; set; }
    }
}
