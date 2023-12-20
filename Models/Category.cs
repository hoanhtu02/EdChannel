using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace EdChannel.Models
{
    [Table("Category")]
    public class Category : AuditModel
    {
        /* 
            Id	The unique id to identify the category.
            Parent Id	The parent id to identify the parent category.
            Title	The category title.
            Meta Title	The meta title to be used for browser title and SEO.
            Slug	The category slug to form the URL.
            Details	The column used to store the category details.
         */
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [DisplayName("Reference(Option)")]
        public long? ParentId { get; set; }
        public string? Image { get; set; }
        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile? ImageFile { get; set; }
        [Required]
        [StringLength(100)]
        public string? Title { get; set; }
        [StringLength(100)]
        [DisplayName("Title MetaTag")]
        public string? MetaTitle { get; set; }
        [Required]
        [StringLength(100)]
        public string? Slug { get; set; }
        [DisplayName("Details")]
        public string? Details { get; set; }

        [ForeignKey("ParentId")]
        [DisplayName("Category marker")]
        public virtual Category? CategoryParent { get; set; }

        [InverseProperty("CategoryParent")]
        public virtual ICollection<Category> CategoryChildren { get; set; } = new List<Category>();
        public virtual ICollection<ProductCategory>  ProductCategories { get; set; } = new List<ProductCategory>();

    }
}
