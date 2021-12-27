using SouqElGomalAdmin.Repository;
using SouqElGomalAdmin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using SouqElGomalAdmin.Models;
using System.IO;

namespace SouqElGomalAdmin.Controllers
{
    public class usersController : Controller
    {

        // GET: users
        public ActionResult Index(int? page, string SearchBy = "Name", string Search="")
        {
            ////////////////////////////////
            if (Session["admin"] == null)
                return Redirect("/admin/login");
            ////////////////////////////////
            ///


            List<UserModel> res = new List<UserModel>();

            if (SearchBy == "Name")
            {
                if(Search == "")
                {
                    res = UserRepo.GetAll().ToList();
                }
                else
                {
                    res = UserRepo.GetAll().Where(i => i.Name.Contains(Search) || Search == null).ToList();
                }
            }

                 
            //List<UserModel> res = UserRepo.GetAll();


            return View(res.ToPagedList(page ?? 1, 7));
        }

        public ActionResult ret(int? page)
        {
            ////////////////////////////////
            if (Session["admin"] == null)
                return Redirect("/admin/login");
            ////////////////////////////////
            ///

            //List<UserModel> res = UserRepo.GetAll().ToList();

            return View();
        }

        [HttpGet]
        public ActionResult Pinding()
        {
            ////////////////////////////////
            if (Session["admin"] == null)
                return Redirect("/admin/login");
            ////////////////////////////////
            ///

            return View();
        }

        //[HttpGet]
        //public ActionResult Add_User()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Add_User(UserType NewUser,HttpPostedFileBase Image1)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        NewUser.Image = new byte[Image1.ContentLength];
        //        Image1.InputStream.Read(NewUser.Image, 0, Image1.ContentLength);

        //        User temp = new User();

        //        temp.Id = NewUser.ID;
        //        temp.Name= NewUser.Name;
        //        temp.Email = NewUser.Email;
        //        temp.Address = NewUser.Address;
        //        temp.UserName = NewUser.UserName;
        //        temp.PhoneNumber = NewUser.PhoneNumber;
        //        temp.Image = NewUser.Image;


        //        UserRepo.Add(temp);
        //    }

        //    return Redirect("/users/Index");
        //}

        [HttpGet]
        public ActionResult UserDetails(string id)
        {
            ////////////////////////////////
            if (Session["admin"] == null)
                return Redirect("/admin/login");
            ////////////////////////////////
            ///


            UserModel res = UserRepo.GetAll().FirstOrDefault(i => i.ID == id);
            return View(res);
        }

        //[HttpGet]
        //public ActionResult Edit_User(string id)
        //{
        //    UserModel res2 = UserRepo.GetAll().FirstOrDefault(i => i.ID == id);
        //    return View(res2);
        //}


        //[HttpPost]
        //public ActionResult Edit_User(UserModel EditedUser)
        //{
        //    AspNetUser res3 = new AspNetUser();

        //    res3.Id = EditedUser.ID;
        //    res3.Name = EditedUser.Name;
        //    res3.Address= EditedUser.Address;
        //    res3.Email = EditedUser.Email;
        //    res3.UserName = EditedUser.UserName;
        //    res3.PhoneNumber = EditedUser.PhoneNumber;

        //    UserRepo.Edit(res3);

        //    return Redirect("/users/Index");
        //}

        [HttpGet]
        public ActionResult Delete_User(string id)
        {
            ////////////////////////////////
            if (Session["admin"] == null)
                return Redirect("/admin/login");
            ////////////////////////////////
            ///

            try
            {
                UserRepo.Remove(id);
            }
            catch(Exception ex)
            {
                TempData["alert"] = 1;
                return Redirect("/users/Index");
            }
            

            return Redirect("/users/Index");
        }
    }
}