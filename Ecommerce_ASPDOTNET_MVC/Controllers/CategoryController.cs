using Ecommerce_ASPDOTNET_MVC.Data;
using Ecommerce_ASPDOTNET_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_ASPDOTNET_MVC.Controllers
{

    public class CategoryController : Controller
    { 
            private readonly ApplicationDbContext _db;
    
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;            
        }
        public IActionResult Index()
        {
            List<Category>objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {

            return View();
        }
    }
}
