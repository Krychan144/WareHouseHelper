using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WareHouseHelper.DataAccess.Models
{
    public class Product : BaseEntity
    {
        [Required]
        [Column(TypeName = "NVARCHAR(100)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(16,2)")]
        public decimal Expense { get; set; }

        [Required]
        public Shop Shop { get; set; }

        [Required]
        public ProductType ProductType { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}