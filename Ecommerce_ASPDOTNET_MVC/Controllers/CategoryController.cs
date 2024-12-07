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
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Same as the Display Order");
            }
            if (ModelState.IsValid)
            {

                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Created Sucessfully";
                return RedirectToAction("Index", "Category");
            }
            return View();

        }
        public IActionResult Edit(int? CategoryId)
        {
            if (CategoryId == null)
            {
                return NotFound();
            }
            Category? category = _db.Categories.Find(CategoryId);
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {

                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Edited Sucessfully";
                return RedirectToAction("Index", "Category");
            }
            return View();
        }

        public IActionResult Delete(int? CategoryId)
        {
            if (CategoryId == null)
            {
                return NotFound();
            }
            Category? category = _db.Categories.Find(CategoryId);
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(Category obj)
        {
            if (obj == null)
            {
                return NotFound();
            }
                _db.Categories.Remove(obj);
                _db.SaveChanges();
            TempData["success"] = "Category Deleted Sucessfully";
            return RedirectToAction("Index", "Category");
            
           
        }



    }
}

