using SouqElGomalAdmin.Repository;
using SouqElGomalAdmin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SouqElGomalAdmin.Controllers
{
    public class usersController : Controller
    {
        // GET: users
        public ActionResult Index()
        {
            List<UserModel> res = UserRepo.GetAll();

            return View(res);
        }

        public ActionResult Add_User()
        {
            return View();
        }

        public ActionResult Remove_User()
        {
            return View();
        }
    }
}