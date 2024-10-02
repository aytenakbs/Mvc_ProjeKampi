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
    public class HeadingController : Controller
    {
        // GET: Heading
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        CategoryManager cm= new CategoryManager(new EFCategoryDal());
        WriterManager wm= new WriterManager(new EFWriterDal());
        public ActionResult Index()
        {
            var values=hm.GetList();
            return View(values);
        }
        [HttpGet]
        public ActionResult Addheading()
        {
            List<SelectListItem> values = (from x in cm.GetCategoryList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();

            List<SelectListItem> values2 = (from x in wm.GetWriterList()
                                            select new SelectListItem
                                            {
                                                Text = x.WriterName + " " + x.WriterSurname,
                                                Value = x.WriterId.ToString()
                                            }).ToList();
            ViewBag.wrValue = values2;
            ViewBag.ctValue=values;
            return View();
        }
        [HttpPost]
        public ActionResult Addheading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.HeadingAdd(heading);
            return RedirectToAction("index");
        }
        

    }
}