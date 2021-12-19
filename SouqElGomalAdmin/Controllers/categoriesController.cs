using SouqElGomalAdmin.Models;
using SouqElGomalAdmin.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using SouqElGomalAdmin.ViewModels;

namespace SouqElGomalAdmin.Controllers
{
    public class categoriesController : Controller
    {
        // GET: categories
        //public ActionResult Index(int? page)
        //{
        //    List<CategoryModel> res = CategoryRepo.GetAll();

        //    return View(res.ToList().ToPagedList(page ?? 1 , 10));
        //}
        public ActionResult Index(int? page, string SearchBy, string Search = "")
        {
            if (Session["admin"] == null)
                return Redirect("/admin/login");

            List<CategoryModel> res;
            if (SearchBy == "ID")
            {
                if (Search == "")
                {
                    res = CategoryRepo.GetAll().ToList();
                }
                else
                {
                    res = CategoryRepo.GetAll().Where(i => i.ID.ToString() == Search || Search == null).ToList();
                }

            }
            else
            {
                if (Search == "")
                {
                    res = CategoryRepo.GetAll().ToList();
                }
                else
                {
                    res = CategoryRepo.GetAll().Where(i => i.Name.Contains(Search) || Search == null).ToList();
                }
            }


            //List<UserModel> res = UserRepo.GetAll();


            return View(res.ToPagedList(page ?? 1, 7));
        }


        [HttpGet]
        public ActionResult Add_category()
        {
            if (Session["admin"] == null)
                return Redirect("/admin/login");

            return View();
        }

        [HttpPost]
        public ActionResult Add_category(CategoryType NewCategory, HttpPostedFileBase Image1)
        {
            if (ModelState.IsValid)
            {
                NewCategory.Image = new byte[Image1.ContentLength];
                Image1.InputStream.Read(NewCategory.Image, 0, Image1.ContentLength);

                Category temp = new Category();

                //temp.ID = NewCategory.ID;
                temp.Name = NewCategory.Name;
                temp.Description = NewCategory.Description;
                temp.Image = NewCategory.Image;

                CategoryRepo.Add(temp);
            } 
            return Redirect("/categories/Index");
        }


        [HttpGet]
        public ActionResult CategoryDetails(int id)
        {
            if (Session["admin"] == null)
                return Redirect("/admin/login");

            CategoryModel res = CategoryRepo.GetAll().FirstOrDefault(i => i.ID == id);

            return View(res);
        }

        [HttpGet]
        public ActionResult Edit_category(int id)
        {
            if (Session["admin"] == null)
                return Redirect("/admin/login");

            CategoryModel res2 = CategoryRepo.GetAll().FirstOrDefault(i => i.ID == id);

            return View(res2);
        }


        [HttpPost]
        public ActionResult Edit_categories(CategoryModel EditedCategory, HttpPostedFileBase Image2)
        {

            EditedCategory.Image = new byte[Image2.ContentLength];
            Image2.InputStream.Read(EditedCategory.Image, 0, Image2.ContentLength);

            Category res3 = new Category();
            res3.ID = EditedCategory.ID;
            res3.Name = EditedCategory.Name;
            res3.Description = EditedCategory.Description;
            res3.Image = EditedCategory.Image;

            CategoryRepo.Edit(res3);

            return Redirect("/categories/Index");
        }

        public ActionResult Delete_category(int id)
        {
            if (Session["admin"] == null)
                return Redirect("/admin/login");

            CategoryRepo.Remove(id);

            return Redirect("/categories/Index");
        }
    }
}