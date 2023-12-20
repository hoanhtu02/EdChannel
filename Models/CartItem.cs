using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdChannel.Models
{
    public class CartItem : AuditModel
    {
        /*
            Id	The unique id to identify the cart item.
            Product Id	The product id to identify the product associated with the cart item.
            Cart Id	The cart id to identify the cart associated with the cart item.
            SKU	The SKU of the product while purchasing it.
            Price	The price of the product while purchasing it.
            Discount	The discount of the product while purchasing it.
            Quantity	The quantity of the product selected by the user.
            Active	The flag to identify whether the product is active on the cart. It can be used to avoid the same product being added to the same cart multiple times.
            Created At	It stores the date and time at which the cart item is created.
            Updated At	It stores the date and time at which the cart item is updated.
            Content	The column used to store the additional details of the cart item
         */
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public long ProductId { get; set; }
        [Required]
        public long CartId { get; set; }

        [StringLength(100)]
        public string? SKU { get; set; }
        public float Price { get; set; } = 0f;
        public float Discount { get; set; } = 0f;
        public int Quantity { get; set; } = 0;
        public bool Active { get; set; } = false;
        public string? Content { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product? Product { get; set; }

        [ForeignKey("CartId")]
        public virtual Cart? Cart { get; set; }
    }
}
