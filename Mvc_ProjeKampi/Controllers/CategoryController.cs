using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
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
        public ActionResult GetCategoryList()
        {
            var categoryvalues=cm.GetCategoryList();
            return View(categoryvalues);
        }
        //public ActionResult AddCategory(Category category)
        //{
            //cm.CategoryAddBL(category);
            //return RedirectToAction("GetCategoryList");
        //}
    }
}