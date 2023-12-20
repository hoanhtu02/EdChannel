using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdChannel.Models
{
    [Table("ProductMeta")]
    [PrimaryKey(nameof(Id), nameof(ProductId))]
    public class ProductMeta
    {
        /*
            Id	The unique id to identify the product meta.
            Product Id	The product id to identify the parent product.
            Key	The key identifying the meta.
            Content	The column used to store the product metadata.
         */
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public long ProductId { get; set; }
        [Required]
        [StringLength(100)]
        public string? Key { get; set; }
        public string? Content { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product? Product { get; set; }

    }
}
