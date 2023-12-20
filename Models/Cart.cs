using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdChannel.Models
{
    public enum CartStatus
    {
        New, Cart, Checkout, Paid, Complete, Abandoned
    }
    public class Cart : AuditModel
    {
        /*
            Id	The unique id to identify the cart.
            User Id	The user id to identify the user or buyer associated with the cart.
            Session Id	The unique session id associated with the cart.
            Token	The unique token associated with the cart to identify the cart over multiple sessions. The same token can also be passed to the Payment Gateway if required.
            Status	The status of the cart can be New, Cart, Checkout, Paid, Complete, and Abandoned.
            First Name	The first name of the user.
            Last Name	The last name of the user.
            Mobile	The mobile number of the user.
            Email	The email of the user.
            Line 1	The first line to store address.
            Line 2	The second line to store address.
            City	The city of the address.
            Province	The province of the address.
            Country	The country of the address.
            Created At	It stores the date and time at which the cart is created.
            Updated At	It stores the date and time at which the cart is updated.
            Content	The column used to store the additional details of the cart.
         */

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long? UserId { get; set; }

        [Required]
        public CartStatus Status { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser? User { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
