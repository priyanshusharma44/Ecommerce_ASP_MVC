using Ecommerce.DataAccess.Repository.IRepository;
using Ecommerce.Models;
using Ecommerce_ASPDOTNET_MVC.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_ASPDOTNET_MVC.Controllers
{

    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepo;

        public CategoryController(ICategoryRepository db)
        {
            _categoryRepo = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _categoryRepo.GetAll().ToList();
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

                _categoryRepo.Add(obj);
                _categoryRepo.Save();
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
            Category? category = _categoryRepo.Get(u => u.CategoryId == CategoryId);
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {

                _categoryRepo.Update(obj);
                _categoryRepo.Save();
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
            Category? category = _categoryRepo.Get(u => u.CategoryId == CategoryId);
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(Category obj)
        {
            if (obj == null)
            {
                return NotFound();
            }
                _categoryRepo.Remove(obj);
                _categoryRepo.Save();
            TempData["success"] = "Category Deleted Sucessfully";
            return RedirectToAction("Index", "Category");
            
           
        }
    }
}

