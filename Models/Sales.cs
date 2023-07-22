using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ODataBridge.Models
{
    [Table("fact_sale")]
    public class Sales
    {
        [Key]
        public int Id { get; set; }

        [Column("period_key")]
        public string PeriodKey { get; set; }

        [Column("product_key")]
        public string ProductKey { get; set; }

        [Column("region_key")]
        public string RegionKey { get; set; }

        [Column("amount")]
        public decimal SalesAmount { get; set; }

        [Column("count")]
        public int SalesCount { get; set; }
    }
}
