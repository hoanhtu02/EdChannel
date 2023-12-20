using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EdChannel.Models
{
    public class Tag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        [StringLength(100)]
        public string? Title { get; set; }
        [StringLength(100)]
        [DisplayName("Title MetaTag")]
        public string? MetaTitle { get; set; }

        [Required]
        [StringLength(100)]
        public string? Slug { get; set; }

        public string? Details { get; set; }

        public virtual ICollection<ProductTag> ProductTags { get; set; } = new List<ProductTag>();

    }
}
