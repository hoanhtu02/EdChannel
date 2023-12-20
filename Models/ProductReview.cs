using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdChannel.Models
{
    [Table("ProductReview")]
    public class ProductReview : AuditModel
    {
        /*
            Id	The unique id to identify the product review.
            Product Id	The product id to identify the parent product.
            Parent Id	The parent id to identify the parent review.
            Title	The review title.
            Rating	The review rating.
            Published	It can be used to identify whether the review is publicly available.
            Created At	It stores the date and time at which the review is submitted.
            Published At	It stores the date and time at which the review is published.
            Content	The column used to store the review details.
         */
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public long ProductId { get; set; }
        public long? ParentId { get; set; }
        [Required]
        [StringLength(100)]
        public string? Title { get; set; }
        [Required]
        public float Rating { get; set; }
        [Required]
        public bool Published { get; set; }
        public  DateTime? PublishedAt { get; set; }
        public  string? Details { get; set; }

        [ForeignKey("ProductId")]
        public virtual  Product? Product { get; set; }

        [ForeignKey("ParentId")]
        public virtual ProductReview? ParentReviews { get; set; }
        public virtual ICollection<ProductReview> ChildReviews { get; set; } = new List<ProductReview>();

    }
}
