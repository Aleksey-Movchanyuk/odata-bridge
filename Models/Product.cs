using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ODataBridge.Models
{
    [Table("dim_product")]
    public class Product
    {
        [Key]
        [Column("product_key")]
        public required string Key { get; set; }

        [Column("product_name")]
        public string? Name { get; set; }
    }
}