using Ecommerce.DataAccess.Repository.IRepository;
using Ecommerce.Models;
using Ecommerce.Models.ViewModels;
using Ecommerce_ASPDOTNET_MVC.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace Ecommerce_ASPDOTNET_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {


            List<Product> objCategoryList = _unitOfWork.Product.GetAll(includeProperties: "Category").ToList();



            return View(objCategoryList);
        }
        public IActionResult Upsert(int? id)
        {
            ProductVM productVM = new()
            {
                CategoryList = _unitOfWork.Category
                .GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.CategoryId.ToString()
                }),
                Product = new Product()
            };
            if (id == null || id == 0)
            {
                return View(productVM);
            }
            else
            {
                //update
                productVM.Product = _unitOfWork.Product.Get(u => u.Id == id);
                return View(productVM);
            }


        }

        [HttpPost]
        public IActionResult Upsert(ProductVM productVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;

                // Handle file upload if there is a new file
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\product");

                    // Delete old image if exists
                    if (!string.IsNullOrEmpty(productVM.Product.ImageUrl))
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, productVM.Product.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    // Save new image
                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    productVM.Product.ImageUrl = @"\images\product\" + fileName;
                }

                // Add or update the product
                if (productVM.Product.Id == 0)
                {
                    _unitOfWork.Product.Add(productVM.Product); // Add if it's a new product
                }
                else
                {
                    _unitOfWork.Product.Update(productVM.Product); // Update if it's an existing product
                }

                _unitOfWork.Save(); // Save changes
                TempData["success"] = productVM.Product.Id == 0 ? "Product Created Successfully" : "Product Updated Successfully";
                return RedirectToAction("Index", "Product");
            }
            else
            {
                // If the model is not valid, reload categories for the dropdown
                productVM.CategoryList = _unitOfWork.Category
                    .GetAll()
                    .Select(u => new SelectListItem
                    {
                        Text = u.Name,
                        Value = u.CategoryId.ToString()
                    });

                return View(productVM);
            }
        }
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Product> objCategoryList = _unitOfWork.Product.GetAll(includeProperties: "Category").ToList();
            return Json(new { data = objCategoryList });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {

            var productToBeDeleted  = _unitOfWork.Product.Get(u=>u.Id == id);

            if (productToBeDeleted == null)
            {
                return Json(new {success = false, message = "Error while deleting"});
            }
            var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath
                , productToBeDeleted.ImageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }
            _unitOfWork.Product.Remove(productToBeDeleted);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Sucessful" });

        }

        #endregion
    }
}




