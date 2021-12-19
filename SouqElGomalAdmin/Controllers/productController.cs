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

namespace SouqElGomalAdmin.Controllers
{
    public class productController : Controller
    {
        // GET: product
        //public ActionResult Index(int? page)
        //{
        //    List<ProductModel> res = ProductRepo.GetAll();
        //    return View(res.ToList().ToPagedList(page ?? 1, 10));
        //}

        public ActionResult Index(int? page, string SearchBy, string Search = "")
        {
            if (Session["admin"] == null)
                return Redirect("/admin/login");

            List<ProductModel> res;
            if (SearchBy == "ID")
            {
                if (Search == "")
                {
                    res = ProductRepo.GetAll().ToList();
                }
                else
                {
                    res = ProductRepo.GetAll().Where(i => i.ID.ToString() == Search || Search == null).ToList();
                }

            }
            else
            {
                if (Search == "")
                {
                    res = ProductRepo.GetAll().ToList();
                }
                else
                {
                    res = ProductRepo.GetAll().Where(i => i.Name.Contains(Search) || Search == null).ToList();
                }
            }


            //List<UserModel> res = UserRepo.GetAll();


            return View(res.ToPagedList(page ?? 1, 7));
        }

        [HttpGet]
        public ActionResult Add_Product()
        {
            if (Session["admin"] == null)
                return Redirect("/admin/login");

            ViewBag.cat = new SelectList(CategoryRepo.GetAll(),"ID","Name");
            return View();
        }

        //public List<Category> getCattegory()                            // for dropDown list
        //{
        //    API5SouqElGomlaEntities x = new API5SouqElGomlaEntities();
        //    List<Category> cat = x.Categories.ToList();
        //    return cat;
        //}

        [HttpPost]
        public ActionResult Add_product(ProductType NewProd, HttpPostedFileBase Image1)
        {
            if (ModelState.IsValid)
            {
                NewProd.Image = new byte[Image1.ContentLength];
                Image1.InputStream.Read(NewProd.Image, 0, Image1.ContentLength);

                Product temp = new Product();

                temp.Name = NewProd.Name;
                temp.Description = NewProd.Description;
                temp.Price = NewProd.Price;
                temp.CategoryID = NewProd.CategoryID;
                temp.UnitWeight = NewProd.UnitWeight;
                temp.Image = NewProd.Image;

                ProductRepo.Add(temp);
            }
            return Redirect("/product/Index");
        }


        [HttpGet]
        public ActionResult ProductDetails(int id)
        {
            if (Session["admin"] == null)
                return Redirect("/admin/login");

            ProductModel res = ProductRepo.GetAll().FirstOrDefault(i => i.ID == id);
            return View(res);
        }

        [HttpGet]
        public ActionResult Edit_Product(int id)
        {
            ProductModel res2 = ProductRepo.GetAll().FirstOrDefault(i => i.ID == id);
            return View(res2);
        }


        [HttpPost]
        public ActionResult Edit_Product(ProductModel EditedProduct, HttpPostedFileBase Image2)
        {
            if (Session["admin"] == null)
                return Redirect("/admin/login");

            EditedProduct.Image = new byte[Image2.ContentLength];
            Image2.InputStream.Read(EditedProduct.Image, 0, Image2.ContentLength);

            Product res3 = new Product();

            res3.ID = EditedProduct.ID;
            res3.Name = EditedProduct.Name;
            res3.CategoryID = EditedProduct.CategoryID;
            res3.Price = EditedProduct.Price;
            res3.Image = EditedProduct.Image;
            res3.UnitWeight = EditedProduct.UnitWeight;
            res3.Description = EditedProduct.Description;

            ProductRepo.Edit(res3);

            return Redirect("/product/Index");
        }

        public ActionResult Delete_Product(int id)
        {
            if (Session["admin"] == null)
                return Redirect("/admin/login");

            ProductRepo.Remove(id);

            return Redirect("/product/Index");
        }

    }
}