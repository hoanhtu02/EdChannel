using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdChannel.Models
{
    [Table("Product")]
    public class Product : AuditModel
    {
        /*
            Id	The unique id to identify the product.
            User Id	The user id to identify the admin or vendor.
            Title	The product title to be displayed on the Shop Page and Product Page.
            Meta Title	The meta title to be used for browser title and SEO.
            Slug	The slug to form the URL.
            Summary	The summary to mention the key highlights.
            Type	The type to distinguish between the different product types.
            SKU	The Stock Keeping Unit to track the product inventory.
            Price	The price of the product.
            Discount	The discount on the product.
            Quantity	The available quantity of the product.
            Shop	It can be used to identify whether the product is publicly available for shopping.
            Created At	It stores the date and time at which the product is created.
            Updated At	It stores the date and time at which the product is updated.
            Published At	It stores the date and time at which the product is published on the Shop.
            Starts At	It stores the date and time at which the product sale starts.
            Ends At	It stores the date and time at which the product sale ends.
            Content	The column used to store the additional details of the product.
         */
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public long UserId { get; set; }
        [Required]
        [StringLength(100)]
        public string? Title { get; set; }
        [StringLength(100)]
        [DisplayName("Meta title for SEO")]
        public string? MetaTitle { get; set; }
        [Required]
        [StringLength(100)]
        public string? Slug { get; set; }
        public string? Summary{ get; set; }
        [Required]
        public  string? Type { get; set; }
        [Required]
        [StringLength(100)]
        [DisplayName("SKU (...sizes:...colors)")]
        public  string? SKU { get; set; }
        [Required]
        [Range(0, float.MaxValue)]
        public float? Price { get; set; } = 0f;
        [Range(0,100)]
        public float? Discount { get; set; } = 0f;
        [Required]
        [Range(0, int.MaxValue)]
        public int? Quantity { get; set; } = 0;
        [Required]
        [DisplayName("Publish?")]
        public bool IsPublished { get; set; } = false;
        public DateTime? PublishedAt { get; set; } = DateTime.UtcNow;
        [DisplayName("Start discount")]
        public DateTime? StartAt { get; set; }
        [DisplayName("End discount")]
        public DateTime? EndAt { get; set; }
        [DisplayName("Describe (Also for SEO)")]
        public string? Details { get; set; }
        public string? Image { get; set; }
        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile? ImageFile { get; set; }
        [NotMapped]
        [DisplayName("Sub Category")]
        public long? SubCategoryId { get; set; }
        [NotMapped]
        [DisplayName("Tags")]
        public List<string>? FullStringTags { get; set; }

        [ForeignKey("UserId")]  
        public virtual ApplicationUser? User { get; set; }
        public virtual ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>();
        public virtual ICollection<ProductCategory> ProductCategories{ get; set; } = new List<ProductCategory>();
        public virtual ICollection<ProductMeta> ProductMetas { get; set; } = new List<ProductMeta>();   
        public virtual ICollection<ProductTag> ProductTags { get; set; } = new List<ProductTag>();
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem> ();
        public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    }
}
