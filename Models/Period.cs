using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ODataBridge.Models
{
    [Table("dim_period")]
    public class Period
    {
        [Key]
        [Column("period_key")]
        public string Key { get; set; }

        [Column("period_name")]
        public string? Name { get; set; }

        [Column("period_order")]
        public int? Order { get; set; }
    }
}
