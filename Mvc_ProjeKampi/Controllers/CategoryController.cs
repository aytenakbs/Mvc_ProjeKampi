using BusinessLayer.Concrete;
using BusinessLayer.Validations;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using FluentValidation.Results;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_ProjeKampi.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager cm=new CategoryManager(new EFCategoryDal());
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetCategoryList()
        {
            var categoryvalues=cm.GetCategoryList();
            return View(categoryvalues);
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult result = categoryValidator.Validate(category);
            if (result.IsValid)
            {
                cm.CategoryAdd(category);
                return RedirectToAction("GetCategoryList");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}