using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ODataBridge.Models
{
    [Table("dim_region")]
    public class Region
    {
        [Key]
        [Column("region_key")]
        public required string Key { get; set; }

        [Column("region_name")]
        public string? Name { get; set; }
    }
}