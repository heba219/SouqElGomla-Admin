using SouqElGomalAdmin.Models;
using SouqElGomalAdmin.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SouqElGomalAdmin.Controllers
{
    public class categoriesController : Controller
    {
        // GET: categories
        public ActionResult Index()
        {
            List<CategoryModel> res = CategoryRepo.GetAll();

            return View(res);
        }


        public ActionResult Add_category()
        {
            return View();
        }

        public ActionResult Remove_category()
        {
            return View();
        }
    }
}