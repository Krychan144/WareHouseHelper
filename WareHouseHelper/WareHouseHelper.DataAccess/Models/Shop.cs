using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WareHouseHelper.DataAccess.Models
{
    public class Shop : BaseEntity
    {
        public Shop()
        {
            Products = new HashSet<Product>();
        }

        public virtual ICollection<Product> Products { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(100)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(11,0)")]
        public decimal Phone { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(100)")]
        public string Adress { get; set; }
    }
}