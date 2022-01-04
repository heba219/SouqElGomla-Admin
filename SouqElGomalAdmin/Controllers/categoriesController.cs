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

        public ActionResult Index(int? page, string SearchBy="Name", string Search = "")
        {
            ////////////////////////////////
            if (Session["admin"] == null)
                return Redirect("/admin/login");
            ////////////////////////////////
            ///


            List<CategoryModel> res = new List<CategoryModel>() ;

            if (SearchBy == "Name")
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
            ////////////////////////////////
            if (Session["admin"] == null)
                return Redirect("/admin/login");
            ////////////////////////////////
            ///


            return View();
        }

        [HttpPost]
        public ActionResult Add_category(CategoryModel NewCategory, HttpPostedFileBase Image1)
        {
            ////////////////////////////////
            if (Session["admin"] == null)
                return Redirect("/admin/login");
            ////////////////////////////////
            ///
            try
            {
                foreach (var i in CategoryRepo.GetAll())                              //check for Name unique
                {
                    if (NewCategory.Name == i.Name)
                    {
                        ViewBag.existingName = "*This Category Is Already Existing";
                        return View();
                    }
                }

                if (!ModelState.IsValid)                                              //check for Validation
                {
                    return View();
                }

                else
                {
                    Category temp = new Category();

                    if (Image1 != null)
                    {
                        NewCategory.Image = new byte[Image1.ContentLength];
                        Image1.InputStream.Read(NewCategory.Image, 0, Image1.ContentLength);

                    
                       //temp.ID = NewCategory.ID;
                        temp.Name = NewCategory.Name;
                        temp.Description = NewCategory.Description;
                        temp.Image = NewCategory.Image;
                    }
                    else
                    {
                        //temp.ID = NewCategory.ID;
                        temp.Name = NewCategory.Name;
                        temp.Description = NewCategory.Description;
                    }

                
                    CategoryRepo.Add(temp);
                    TempData["alert"] = 3;
                }
            }
            catch(Exception es)
            {
                TempData["alert"] = 5;
                return Redirect("/categories/Index");
            }


            return Redirect("/categories/Index");
        }


        [HttpGet]
        public ActionResult CategoryDetails(int id)
        {
            ////////////////////////////////
            if (Session["admin"] == null)
                return Redirect("/admin/login");
            ////////////////////////////////
            ///


            CategoryModel res = CategoryRepo.GetAll().FirstOrDefault(i => i.ID == id);

            return View(res);
        }

        [HttpGet]
        public ActionResult Edit_category(int id)
        {
            ////////////////////////////////
            if (Session["admin"] == null)
                return Redirect("/admin/login");
            ////////////////////////////////

            CategoryModel res2 = CategoryRepo.GetAll().FirstOrDefault(i => i.ID == id);

            return View(res2);
        }


        [HttpPost]
        public ActionResult Edit_categories(CategoryModel EditedCategory, HttpPostedFileBase Image2)
        {
            ////////////////////////////////
            if (Session["admin"] == null)
                return Redirect("/admin/login");
            ////////////////////////////////
            ///
            try
            {
                if(!ModelState.IsValid)
                {
                    CategoryModel res3 = CategoryRepo.GetAll().FirstOrDefault(i => i.ID == EditedCategory.ID);

                    return View(res3);
                }
                else
                {
                    Category res3 = new Category();
                    if (Image2 != null)
                    {
                        EditedCategory.Image = new byte[Image2.ContentLength];
                        Image2.InputStream.Read(EditedCategory.Image, 0, Image2.ContentLength);


                        res3.ID = EditedCategory.ID;
                        res3.Name = EditedCategory.Name;
                        res3.Description = EditedCategory.Description;
                        res3.Image = EditedCategory.Image;
                    }
                    else
                    {
                        CategoryModel resimg = CategoryRepo.GetAll().FirstOrDefault(i => i.ID == EditedCategory.ID);

                        res3.ID = EditedCategory.ID;
                        res3.Name = EditedCategory.Name;
                        res3.Description = EditedCategory.Description;
                        res3.Image = resimg.Image;
                    }


                    CategoryRepo.Edit(res3);
                    TempData["alert"] = 4;
                }

            }
            catch(Exception er)
            {
                TempData["alert"] = 5;
                return Redirect("/categories/Index");
            }



            return Redirect("/categories/Index");
        }

        public ActionResult Delete_category(int id)
        {
            ////////////////////////////////
            if (Session["admin"] == null)
                return Redirect("/admin/login");
            ////////////////////////////////
            ///

            try
            {
                var checkQuantity = CategoryRepo.GetAll().FirstOrDefault(i => i.ID == id);


                if (checkQuantity.Products.Count() > 0)
                {
                    TempData["alert"] = 1;
                }
                if (checkQuantity.Products.Count() == 0)
                {
                    TempData["alert"] = 2;
                    CategoryRepo.Remove(id);
                }
            }
            catch(Exception ex)
            {
                TempData["alert"] = 5;
                return Redirect("/categories/Index");
            }


            return Redirect("/categories/Index");
        }
    }
}