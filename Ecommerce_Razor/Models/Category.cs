using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Ecommerce_Razor.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Max Lenght is 20")]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 50, ErrorMessage = "Range Must be between 1 to 50")]
        public int DisplayOrder { get; set; }
    }
}
