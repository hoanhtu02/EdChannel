using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace EdChannel.Models
{
    [PrimaryKey(nameof(ProductId), nameof(TagId))]
    public class ProductTag
    {
        [Key]
        public long ProductId { get; set; }
        [Key]
        public long TagId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product? Product { get; set; }

        [ForeignKey("TagId")]
        public virtual  Tag? Tag { get; set; }

    }
}
