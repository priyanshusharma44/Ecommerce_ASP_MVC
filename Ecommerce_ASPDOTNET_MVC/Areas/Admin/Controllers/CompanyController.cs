using Ecommerce.DataAccess.Repository.IRepository;
using Ecommerce.Models;
using Ecommerce.Models.ViewModels;
using Ecommerce.Utility;
using Ecommerce_ASPDOTNET_MVC.DataAccess.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace Ecommerce_ASPDOTNET_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
/*    [Authorize(Roles =SD.Role_Admin)]*/
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            
        }
        public IActionResult Index()
        {

            List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
            return View(objCompanyList);
        }
        public IActionResult Upsert(int? id)
        {
           
            if (id == null || id == 0)
            {
                return View(new Company());
            }
            else
            {
                //update
                Company company = _unitOfWork.Company.Get(u => u.Id == id);
                return View(company);
            }


        }

        [HttpPost]
        public IActionResult Upsert(Company CompanyObj)
        {
            if (ModelState.IsValid)
            {
                

                
                if (CompanyObj.Id == 0)
                {
                    _unitOfWork.Company.Add(CompanyObj);
                    TempData["success"] = "Company Created Successfully";
                }
                else
                {
                    _unitOfWork.Company.Update(CompanyObj);
                    TempData["success"] = "Company Updated Successfully";
                }

                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            

            return View(CompanyObj);
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Company> objCategoryList = _unitOfWork.Company.GetAll().ToList();
            return Json(new { data = objCategoryList });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {

            var CompanyToBeDeleted  = _unitOfWork.Company.Get(u=>u.Id == id);

            if (CompanyToBeDeleted == null)
            {
                return Json(new {success = false, message = "Error while deleting"});
            }
           
            _unitOfWork.Company.Remove(CompanyToBeDeleted);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Sucessful" });

        }

        #endregion
    }
}




