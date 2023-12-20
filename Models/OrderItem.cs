using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EdChannel.Models
{
    public class OrderItem : AuditModel
    {
        /*
            Id	The unique id to identify the ordered item.
            Product Id	The product id to identify the product associated with the ordered item.
            Order Id	The order id to identify the order associated with the ordered item.
            SKU	The SKU of the product while purchasing it.
            Price	The price of the product while purchasing it.
            Discount	The discount of the product while purchasing it.
            Quantity	The quantity of the product selected by the user.
            Created At	It stores the date and time at which the ordered item is created.
            Updated At	It stores the date and time at which the ordered item is updated.
            Content	The column used to store the additional details of the ordered item.
         */
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required] public long ProductId { get; set; } = 0;
        [Required] public long OrderId { get; set; } = 0;
        public int Quantity { get; set; } = 0;
        [ForeignKey("ProductId")]
        public virtual Product? Product { get; set; }
        [ForeignKey("OrderId")]
        public virtual Order? Order { get; set; }
    }
}
