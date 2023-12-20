using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EdChannel.Models
{
    public enum TransactionType
    {
        Credit, Debit
    }
    public enum TransactionMode
    {
        Offline, CashOnDelivery, Cheque, Draft, Wired, Online
    }
    public enum TransactionStatus
    {
        New, Cancelled, Failed, Pending, Declined, Rejected, Success
    }   

    public class Transaction : AuditModel
    {
        /*
            Id	The unique id to identify the transaction.
            User Id	The user id to identify the user associated with the transaction.
            Order Id	The order id to identify the order associated with the transaction.
            Code	The payment id provided by the payment gateway.
            Type	The type of order transaction can be either Credit or Debit.
            Mode	The mode of the order transaction can be Offline, Cash On Delivery, Cheque, Draft, Wired, and Online.
            Status	The status of the order transaction can be New, Cancelled, Failed, Pending, Declined, Rejected, and Success.
            Created At	It stores the date and time at which the order transaction is created.
            Updated At	It stores the date and time at which the order transaction is updated.
            Content	The column used to store the additional details of the transaction.
         */
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        [StringLength(100)]
        public string? Code { get; set; } = null;
        [Required]
        public TransactionType? Type { get; set; } = null;
        [Required]
        public TransactionMode? Mode { get; set; } = null;
        [Required]
        public TransactionStatus? Status { get; set; } = null;
        public string? Content { get; set; } = null;

        [ForeignKey("UserId")]
        public virtual ApplicationUser? User { get; set; }
        public long UserId { get; set; }
        [ForeignKey("OrderId")]
        public virtual Order? Order { get; set; }
        public long OrderId { get; set; }
    }
}
