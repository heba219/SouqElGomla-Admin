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
        public ActionResult Index(int? page, string SearchBy = "",  string Search = "", string Category = "")
        {
            ////////////////////////////////
            if (Session["admin"] == null)
                return Redirect("/admin/login");
            ////////////////////////////////
            ///

            List<ProductModel> res = new List<ProductModel>();

            try
            {

            ViewBag.cat1 = new SelectList(CategoryRepo.GetAll(), "ID", "Name");     // get All Categories

                if (Search == "" && Category == "")                              // Filter
                 {
                    res = ProductRepo.GetAll().ToList();
                }
                else if (Search.Length > 0 && Category == "")
                {
                    res = ProductRepo.GetAll().Where(i => i.Name.Contains(Search) || Search == null).ToList();
                }
                else if (Category.Length > 0 && Search == "")
                {
                     res = ProductRepo.GetAll().Where(i => i.CategoryID == int.Parse(Category)).ToList();
                }
                else 
                {
                    res = ProductRepo.GetAll().Where(i => i.CategoryID == int.Parse(Category)).ToList();
                    res = res.Where(i => i.Name.Contains(Search) || Search == null).ToList();
                }
            }
            catch(Exception ex)
            {
                TempData["alert"] = 5;
            }

            return View(res.ToPagedList(page ?? 1, 7));
        }



        [HttpGet]
        public ActionResult Add_Product()
        {
            ////////////////////////////////
            if (Session["admin"] == null)
                return Redirect("/admin/login");
            ////////////////////////////////
            ///

            ViewBag.cat2 = new SelectList(CategoryRepo.GetAll(), "ID", "Name");     //for category dropDownList
            return View();
        }


        [HttpPost]
        public ActionResult Add_product(ProductModel NewProd, HttpPostedFileBase Image1, string unit)
        {

            ////////////////////////////////
            if (Session["admin"] == null)
                return Redirect("/admin/login");
            ////////////////////////////////
            ///


            try
            {
                foreach (var i in ProductRepo.GetAll())                              //check for Name unique
                {
                    if (NewProd.Name == i.Name)
                    {
                        ViewBag.existingName2 = "*This Product Is Already Existing";
                        ViewBag.cat2 = new SelectList(CategoryRepo.GetAll(), "ID", "Name");
                        return View();
                    }
                }


                Product temp = new Product();                             //check Validation


                if (!ModelState.IsValid)
                {
                    ViewBag.cat2 = new SelectList(CategoryRepo.GetAll(), "ID", "Name");
                    return View();
                }
                else
                {
                    if (Image1 != null)                                                        // becouse if image null it will make error so this code for that
                    {
                        NewProd.Image = new byte[Image1.ContentLength];
                        Image1.InputStream.Read(NewProd.Image, 0, Image1.ContentLength);

                        temp.Name = NewProd.Name;
                        temp.Description = NewProd.Description;
                        temp.Price = NewProd.Price;
                        temp.CategoryID = NewProd.CategoryID;
                        if(unit == "0")
                        {
                            temp.UnitWeight = NewProd.UnitWeight+"-gm";
                        }
                        else if (unit == "1")
                        {
                            temp.UnitWeight = NewProd.UnitWeight + "-kg";
                        }
                        else if (unit == "2")
                        {
                            temp.UnitWeight = NewProd.UnitWeight + "-ml";
                        }
                        else if (unit == "3")
                        {
                            temp.UnitWeight = NewProd.UnitWeight + "-L";
                        }
                        temp.Image = NewProd.Image;
                        temp.Quantity = NewProd.Quantity;
                        temp.PackgesNumber = NewProd.PackgesNumber;
                        temp.IsApproved = true;

                    }
                    else
                    {
                        temp.Name = NewProd.Name;
                        temp.Description = NewProd.Description;
                        temp.Price = NewProd.Price;
                        temp.CategoryID = NewProd.CategoryID;
                        if (unit == "0")
                        {
                            temp.UnitWeight = NewProd.UnitWeight + "-gm";
                        }
                        else if (unit == "1")
                        {
                            temp.UnitWeight = NewProd.UnitWeight + "-kg";
                        }
                        else if (unit == "2")
                        {
                            temp.UnitWeight = NewProd.UnitWeight + "-ml";
                        }
                        else if (unit == "3")
                        {
                            temp.UnitWeight = NewProd.UnitWeight + "-L";
                        }
                        temp.Quantity = NewProd.Quantity;
                        temp.PackgesNumber = NewProd.PackgesNumber;
                        temp.IsApproved = true;
                    }

                    ViewBag.cat2 = new SelectList(CategoryRepo.GetAll(), "ID", "Name");
                    ProductRepo.Add(temp);
                    TempData["alert"] = 1;
                }
            }

            catch(Exception exx)
            {
                TempData["alert"] = 5;
            }



            return Redirect("/product/Index");
        }


        [HttpGet]
        public ActionResult ProductDetails(int id)
        {
            ////////////////////////////////
            if (Session["admin"] == null)
                return Redirect("/admin/login");
            ////////////////////////////////
            ///
            ProductModel res = new ProductModel();
            string category;

            try
            {
                 res = ProductRepo.GetAll().FirstOrDefault(i => i.ID == id);
                var x = CategoryRepo.GetAll().FirstOrDefault(i => i.ID == res.CategoryID);
                category = x.Name;
                ViewBag.CategoryName = category;
            }
            catch(Exception ex)
            {
                TempData["alert"] = 5;
            }

            return View(res);
        }

        [HttpGet]
        public ActionResult Edit_Product(int id)
        {
            ////////////////////////////////
            if (Session["admin"] == null)
                return Redirect("/admin/login");
            ////////////////////////////////
            ///
            ProductModel res2 = ProductRepo.GetAll().FirstOrDefault(i => i.ID == id);
            ViewBag.cat3 = new SelectList(CategoryRepo.GetAll(), "ID", "Name");
            string[] strTemp = (res2.UnitWeight).Split('-');
            try
            {
                ViewBag.unit = strTemp[1];
                ViewBag.number = strTemp[0];
            }
            catch
            {
                return View(res2);
            }
            return View(res2);
        }


        [HttpPost]
        public ActionResult Edit_Product(ProductModel EditedProduct, HttpPostedFileBase Image2, string unit)
        {
            ////////////////////////////////
            if (Session["admin"] == null)
                return Redirect("/admin/login");
            ////////////////////////////////
            ///

            ProductModel PeforeEdited = ProductRepo.GetAll().FirstOrDefault(i => i.ID == EditedProduct.ID);
            try
            {
                    foreach (var i in ProductRepo.GetAll())                                                //check for Name unique
                    {
                        if (EditedProduct.Name == i.Name && EditedProduct.Name != PeforeEdited.Name)
                        {
                            ViewBag.existingName3 = "*This Product Is Already Existing";
                            ViewBag.cat3 = new SelectList(CategoryRepo.GetAll(), "ID", "Name");
                            return View();
                        }
                    }

                    Product res3 = new Product();

                if (!ModelState.IsValid)
                {
                    ViewBag.cat3 = new SelectList(CategoryRepo.GetAll(), "ID", "Name");
                    return View();
                }
                else
                {
                    if (Image2 != null)
                    {
                        EditedProduct.Image = new byte[Image2.ContentLength];
                        Image2.InputStream.Read(EditedProduct.Image, 0, Image2.ContentLength);

                        res3.ID = EditedProduct.ID;
                        res3.Name = EditedProduct.Name;
                        res3.CategoryID = EditedProduct.CategoryID;
                        res3.Price = EditedProduct.Price;
                        res3.Image = EditedProduct.Image;
                        if (unit == "0")
                        {
                            res3.UnitWeight = EditedProduct.UnitWeight + "-gm";
                        }
                        else if (unit == "1")
                        {
                            res3.UnitWeight = EditedProduct.UnitWeight + "-kg";
                        }
                        else if (unit == "2")
                        {
                            res3.UnitWeight = EditedProduct.UnitWeight + "-ml";
                        }
                        else if (unit == "3")
                        {
                            res3.UnitWeight = EditedProduct.UnitWeight + "-L";
                        }
                        res3.Description = EditedProduct.Description;
                        res3.Quantity = EditedProduct.Quantity;
                        res3.PackgesNumber = EditedProduct.PackgesNumber;
                    }

                    else
                    {
                        ProductModel resimg = ProductRepo.GetAll().FirstOrDefault(i => i.ID == EditedProduct.ID);

                        res3.ID = EditedProduct.ID;
                        res3.Name = EditedProduct.Name;
                        res3.CategoryID = EditedProduct.CategoryID;
                        res3.Image = resimg.Image;
                        res3.Price = EditedProduct.Price;
                        if (unit == "0")
                        {
                            res3.UnitWeight = EditedProduct.UnitWeight + "-gm";
                        }
                        else if (unit == "1")
                        {
                            res3.UnitWeight = EditedProduct.UnitWeight + "-kg";
                        }
                        else if (unit == "2")
                        {
                            res3.UnitWeight = EditedProduct.UnitWeight + "-ml";
                        }
                        else if (unit == "3")
                        {
                            res3.UnitWeight = EditedProduct.UnitWeight + "-L";
                        }
                        res3.Description = EditedProduct.Description;
                        res3.Quantity = EditedProduct.Quantity;
                        res3.PackgesNumber = EditedProduct.PackgesNumber;
                    }

                        ProductRepo.Edit(res3);
                        TempData["alert"] = 2;
                }

            }catch(Exception ex)
            {
                TempData["alert"] = 5;
            }



            return Redirect("/product/Index");
        }





        public ActionResult Delete_Product(int id)
        {
            ////////////////////////////////
            if (Session["admin"] == null)
                return Redirect("/admin/login");
            ////////////////////////////////
            ///
            try
            {
                ProductRepo.Remove(id);
                TempData["alert"] = 3;
            }
            catch(Exception exxx)
            {
                TempData["alert"] = 5;
            }


            return Redirect("/product/Index");
        }

    }
}