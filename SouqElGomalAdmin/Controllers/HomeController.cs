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
        public List<PindingType> StaticMembers = new List<PindingType>() 
        {
            new PindingType(){ID="13", Name="member_1", Address="st123", Email="member_1@mail.com" , PhoneNumber="12345", UserName="member_1"},
            new PindingType() {ID="14", Name="member_2", Address="st123", Email="member2@mail.com" , PhoneNumber="12345", UserName="member_2"},
            new PindingType() {ID="15", Name="member_3", Address="st123", Email="member_41@mail.com" , PhoneNumber="12345", UserName="member_13"},
            new PindingType() {ID="16", Name="member_4", Address="st123", Email="member_51@mail.com" , PhoneNumber="12345", UserName="member_4"}
        };
        int usersCount = UserRepo.GetAll().Count();
        int CategoryCount = CategoryRepo.GetAll().Count();
        int ProductCount = ProductRepo.GetAll().Count();

        string[] names =  new string[15];
        int[] quantity = new int[15];

        List<CategoryModel> Category = CategoryRepo.GetAll();

        // GET: Home
        public ActionResult Index()
        {

            ViewBag.TotalUsers = usersCount;
            ViewBag.TotalCategories = CategoryCount;
            ViewBag.TotalProduct = ProductCount;
            ViewBag.TotalProduct = ProductCount;

            //for(int i= 0; i < 15; i++)
            //{
            //    names[i] = CategoryRepo.GetAll()[i].Name;
            //    quantity[i] = CategoryRepo.GetAll()[i].ID;
            //}

            //ViewBag.Names = names;
            //ViewBag.quantity = quantity;
            if (Session["admin"] == null)
                return Redirect("/admin/login");

            return View(StaticMembers);
        }


        [HttpGet]
        public ActionResult UserDetails(string id)
        {
            PindingType res = StaticMembers.FirstOrDefault(i => i.ID == id);
            if (Session["admin"] == null)
                return Redirect("/admin/login");

            return View(res);
        }


        //[HttpGet]
        //public ActionResult AcceptUser(string id)
        //{
        //    PindingType res = StaticMembers.FirstOrDefault(i => i.ID == id);
        //    UserType user = new UserType();

        //    user.ID = res.ID;
        //    user.Name = res.Name;
        //    user.Email = res.Email;
        //    user.Address = res.Address;
        //    user.UserName = res.UserName;
        //    user.PhoneNumber = res.PhoneNumber;

        //    TempData["usersFromPinding"] = user;

        //    return Redirect();
        //}

    }
}