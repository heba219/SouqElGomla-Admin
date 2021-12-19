using SouqElGomalAdmin.Repository;
using SouqElGomalAdmin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SouqElGomalAdmin.Controllers
{
    public class adminController : Controller
    {
        // GET: admin
        adminLoginRepo adminRebo = new adminLoginRepo();

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(string email, string pass)
        {
            adminLoginModel admin = new adminLoginModel(email, pass);
            List<adminLoginModel> res = adminLoginRepo.GetAll();
            adminLoginModel selectedAdmin = res.FirstOrDefault(i => i.email == admin.email && i.pass == admin.pass);
            if (selectedAdmin == null)
                return View();
            else
            {
                Session["admin"] = admin;

                return Redirect("/Home/Index");
            }
        }
        [HttpGet]
        public ActionResult addAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addAdmin(adminLogin newAdnmin)
        {
            adminRebo.addAdmins(newAdnmin);
            return Redirect("/Home/Index");
        }
        public ActionResult logout()
        {
            Session.Remove("admin");
            return Redirect("/admin/login");
        }
    }
}