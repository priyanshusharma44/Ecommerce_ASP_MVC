using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Author { get; set; }
        [Display(Name = "List Price")]
        public double ListPrice { get; set; }
        //for multi book acqquiring
        [Display(Name = "Price for 1-50")]
        [Range(1,100)]
        public double Price { get; set; }

        //for multi book acqquiring
        [Display(Name = "Price for 50+")]
        [Range(1, 100)]
        public double Price50 { get; set; }

        //for multi book acqquiring
        [Display(Name = "Price for 100+")]
        [Range(1, 100)]
        public double Price100 { get; set; }
    }
}
