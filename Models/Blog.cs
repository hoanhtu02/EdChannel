using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdChannel.Models
{
    [Table("Blog")]

    public class Blog : AuditModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string? Title{ get; set; }
        [Required]

        public string? Slug{ get; set; }

        [StringLength(50)]
        public string? Description { get; set; }

        public string? Content { get; set; }
        public bool Publish { get; set; }

        public long? OwnerId { get; set; }
        public string? OwnerName { get; set; }

        [ForeignKey("OwnerId")]
        public virtual ApplicationUser? User { get; set; }
        [DisplayName("Category")]
        public long? CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }

    }
}
