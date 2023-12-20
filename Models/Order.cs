using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdChannel.Models
{
    public enum OrderStatus
    {
        New, Checkout, Paid, Failed, Shipped, Delivered, Returned, Complete
    }
    public class Order : AuditModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long UserId { get; set; }

        [Required]
        public OrderStatus Status { get; set; }
        public float SubTotal { get; set; } = 0f;
        public float Shipping { get; set; } = 0f;
        public float Total { get; set; } = 0f;
        public float GrandTotal { get; set; } = 0f;
        [StringLength(50)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your first name")]
        public string? FirstName { get; set; } = null;
        [StringLength(50)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your last name")]
        public string? LastName { get; set; } = null;
        [StringLength(10)]
        [Required]
        [Phone(ErrorMessage = "Please enter a valid phone number")]
        public string? Mobile { get; set; } = null;
        [StringLength(50)]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        [Required]
        public string? Email { get; set; } = null;
        [StringLength(100)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your address")]

        public string? Line1 { get; set; } = null;
        [StringLength(50)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your city name")]
        public string? City { get; set; } = null;
        [StringLength(50)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your province name")]
        public string? Province { get; set; } = null;
        [StringLength(50)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your country name")]
        public string? Country { get; set; } = null;
        public string? Content { get; set; } = null;

        [ForeignKey("UserId")]
        public virtual ApplicationUser? User { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    }
}
