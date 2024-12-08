using Ecommerce_Razor.Data1;
using Ecommerce_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace Ecommerce_Razor.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {

      private readonly ApplicationDbContext _db;

            public Category Category { get; set; }
            public EditModel(ApplicationDbContext db)
            {
                _db = db;
            }

        public void OnGet(int? CategoryId)
        {
            if (CategoryId != null && CategoryId != 0)
            {
                Category = _db.Categories.Find(CategoryId);
            }
        }
            
            public IActionResult OnPost()
            {
                _db.Categories.Update(Category);
                _db.SaveChanges();
            TempData["success"] = "Category Edited Sucessfully";
            return RedirectToPage("Index");

            }
            
        }
    }

