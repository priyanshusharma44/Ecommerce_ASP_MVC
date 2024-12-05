using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce_ASPDOTNET_MVC.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
    }
}
