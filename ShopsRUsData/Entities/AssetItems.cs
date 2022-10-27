using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUsData.Entities
{
    [Table("tbl_assetitems")]
    public class AssetItems : BaseEntity<int>
    {
        [Key]
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public string AssetType { get; set; }
        public decimal MarketIntelligencePrice { get; set; }

    }
}
