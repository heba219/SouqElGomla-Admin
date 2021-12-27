using PagedList;
using SouqElGomalAdmin.Models;
using SouqElGomalAdmin.Repository;
using SouqElGomalAdmin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SouqElGomalAdmin.Controllers
{
    public class HomeController : Controller
    {

        int usersCount = UserRepo.GetAll().Count();
        int CategoryCount = CategoryRepo.GetAll().Count();
        int ProductCount = ProductRepo.GetAll().Count();
        int AdminCount = admin.GetAll().Count();
        int OrderCount = OrderRepo.GetAll().Count();

        string[] names =  new string[15];
        int[] quantity = new int[15];

        List<CategoryModel> Category = CategoryRepo.GetAll();

        // GET: Home
        public ActionResult Index(int? page)
        {
            ////////////////////////////////
            if (Session["admin"] == null)
                return Redirect("/admin/login");
            ////////////////////////////////
            ///

            List<adminModel> list = new List<adminModel>();
            list = admin.GetAll();

            ViewBag.TotalUsers = usersCount;
            ViewBag.TotalCategories = CategoryCount;
            ViewBag.TotalProduct = ProductCount;
            ViewBag.TotalAdmin = AdminCount;
            ViewBag.TotalOrders = OrderCount;

            List<OrderModel> res;
            //List<ProductModel> productsName;

            res = OrderRepo.GetAll().ToList();
            ViewBag.orders = res.ToPagedList(page ?? 1, 5);

            return View(list.ToPagedList(page ?? 1, 5));
        }


        [HttpGet]
        public ActionResult UserDetails(string id)
        {
            ////////////////////////////////
            if (Session["admin"] == null)
                return Redirect("/admin/login");
            ////////////////////////////////

            return View();
        }


        public ActionResult Delete_Admin(int id)
        {
            ////////////////////////////////
            if (Session["admin"] == null)
                return Redirect("/admin/login");
            ////////////////////////////////

            admin.Remove(id);

            return Redirect("/admin/Index");
        }

    }
}