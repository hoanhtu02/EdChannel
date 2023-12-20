using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdChannel.Models
{
    [PrimaryKey(nameof(ProductId), nameof(CategoryId))]
    [Table("ProductCategory")]
    public class ProductCategory
    {
        /*
            Product Id	The product id to identify the product.
            Category Id	The category id to identify the category.
         */
        [Column(Order = 0)]
        public long ProductId { get; set; }
        [Column(Order = 1)]
        public long CategoryId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product? Product { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }

    }
}
