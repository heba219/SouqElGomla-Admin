using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SouqElGomalAdmin.Controllers
{
    public class productController : Controller
    {
        // GET: product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add_product()
        {
            return View();
        }

        public ActionResult Remove_product()
        {
            return View();
        }


    }
}