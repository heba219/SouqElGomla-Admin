using PagedList;
using SouqElGomalAdmin.Repository;
using SouqElGomalAdmin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SouqElGomalAdmin.Controllers
{

    public class adminController : Controller
    {
        public string hashPassword;
        public string LoginhashPassword;
        public string EditHashPassword;
        public string DehashPassword;
        public string hash = "f0xle@rn";
        public static string currentAdmin ;
        // GET: admin
        adminLoginRepo adminRebo = new adminLoginRepo();

        public ActionResult Index(int? page, string SearchBy = "Email", string Search = "")
        {
            ////////////////////////////////
            if (Session["admin"] == null)
                return Redirect("/admin/login");
            ////////////////////////////////
            ///

            List<adminModel> list = new List<adminModel>();
            List<adminModel> list2 = new List<adminModel>();
            list = admin.GetAll();

            foreach (var i in list)
            {
                if(i.email == currentAdmin)
                {
                    continue;
                }
                else
                {
                    list2.Add(i);
                }
            }

            if (SearchBy == "Email")
            {
                if (Search == "")
                {
                }
                else
                {
                    list2 = list2.Where(i => i.email == Search).ToList();
                }
            }

            return View(list2.ToPagedList(page ?? 1, 7));
        }


        [HttpGet]
        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult login(string email, string pass)
        {
            try
            {
                    adminLoginModel admin = new adminLoginModel(email, pass);

                    //////////// Encrypt password

                    byte[] data = UTF8Encoding.UTF8.GetBytes(admin.pass);
                    using (MD5CryptoServiceProvider md = new MD5CryptoServiceProvider())
                    {
                        byte[] keys = md.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                        using (TripleDESCryptoServiceProvider tripDis = new TripleDESCryptoServiceProvider()
                        { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                        {
                            ICryptoTransform transform = tripDis.CreateEncryptor();
                            byte[] result = transform.TransformFinalBlock(data, 0, data.Length);
                            LoginhashPassword = Convert.ToBase64String(result, 0, result.Length);
                        }
                    }
                    /////////////////////////////////////////////////////////////////////////////
                    ///
                    ///
                    List<adminLoginModel> res = adminLoginRepo.GetAllAfterEdit();

                    adminLoginModel selectedAdmin = res.FirstOrDefault(i => i.email == admin.email && i.pass == LoginhashPassword);
                    currentAdmin = email;

                    if (selectedAdmin == null)
                        return View();
                    else
                    {
                        Session["admin"] = admin;

                        return Redirect("/Home/Index");
                    }
            }
            catch(Exception ex)
            {
                TempData["alert"] = 5;
                return Redirect("/admin/login");
            }


        }




        [HttpGet]
        public ActionResult addAdmin()
        {
            ////////////////////////////////
            if (Session["admin"] == null)
                return Redirect("/admin/login");
            ////////////////////////////////
            ///

            return View();
        }

        [HttpPost]
        public ActionResult addAdmin(adminLogin newAdnmin)
        {

            if (!ModelState.IsValid)                                              //check for Validation
            {
                return View();
            }

            else
            {
                foreach (var i in adminLoginRepo.GetAll())                              //check for email unique
                {
                    if (newAdnmin.email == i.email)
                    {
                        ViewBag.existingEmail = "*This Email Is Already Existing";
                        return View();
                    }
                }

                if (newAdnmin.password != newAdnmin.ConfirmPassword)                  //check for password
                {
                    ViewBag.psaaMatch = "*Password Dosen't Match";
                    return View();
                }


                //////////// Encrypt password

                byte[] data = UTF8Encoding.UTF8.GetBytes(newAdnmin.password);
                using (MD5CryptoServiceProvider md = new MD5CryptoServiceProvider())
                {
                    byte[] keys = md.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                    using (TripleDESCryptoServiceProvider tripDis = new TripleDESCryptoServiceProvider()
                    { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                    {
                        ICryptoTransform transform = tripDis.CreateEncryptor();
                        byte[] result = transform.TransformFinalBlock(data, 0, data.Length);
                        hashPassword = Convert.ToBase64String(result, 0, result.Length);
                    }
                }
                /////////////////////////////////////////////////////////////////////////////
                ///
                ///

                newAdnmin.password = hashPassword;                                     //add hashed password to repo to add to database

                adminRebo.addAdmins(newAdnmin);
                TempData["alert"] = 1;
            }
            return Redirect("/admin/Index");
        }

        [HttpGet]
        public ActionResult AdminDetails(int id)
        {
            ////////////////////////////////
            if (Session["admin"] == null)
                return Redirect("/admin/login");
            ////////////////////////////////
            ///


            adminModel res = admin.GetAll().FirstOrDefault(i => i.id == id);

            return View(res);
        }


        [HttpGet]
        public ActionResult Edit_admin()
        {
            ////////////////////////////////
            if (Session["admin"] == null)
                return Redirect("/admin/login");
            ////////////////////////////////
            ///


            adminModel res2 = admin.GetAll().FirstOrDefault(i => i.email== currentAdmin);


            //////////// Decrypt password

            byte[] data2 = Convert.FromBase64String(res2.password);
            using (MD5CryptoServiceProvider md = new MD5CryptoServiceProvider())
            {
                byte[] keys = md.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDis = new TripleDESCryptoServiceProvider()
                { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDis.CreateDecryptor();
                    byte[] result = transform.TransformFinalBlock(data2, 0, data2.Length);
                    DehashPassword = UTF8Encoding.UTF8.GetString(result);
                }
            }
            /////////////////////////////////////////////////////////////////////////////
            ///
            ///

            res2.password = DehashPassword;
            TempData["alert"] = 2;
            return View(res2);
        }


        [HttpPost]
        public ActionResult Edit_admin(adminModel EditedCategory)
        {
            if (EditedCategory.password != EditedCategory.Confirmpassword)    // check for password
            {
                ViewBag.psaaMatch = "*Password Dosen't Match";
                return View();
            }

            if (!ModelState.IsValid)                                         // check for validation
            {
                return View();
            }

            if (Session["admin"] == null)                                 
                return Redirect("/admin/login");


            //////////// Encrypt password

            byte[] data = UTF8Encoding.UTF8.GetBytes(EditedCategory.password);
            using (MD5CryptoServiceProvider md = new MD5CryptoServiceProvider())
            {
                byte[] keys = md.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDis = new TripleDESCryptoServiceProvider()
                { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDis.CreateEncryptor();
                    byte[] result = transform.TransformFinalBlock(data, 0, data.Length);
                    EditHashPassword = Convert.ToBase64String(result, 0, result.Length);
                }
            }
            /////////////////////////////////////////////////////////////////////////////
            ///
            /// 
            adminLogin res3 = new adminLogin();                                          // edit admin
            res3.id = EditedCategory.id;
            res3.name = EditedCategory.name;
            res3.email = EditedCategory.email;
            res3.mobile = EditedCategory.mobile;
            res3.Address = EditedCategory.Address;
            res3.password = EditHashPassword;
            res3.ConfirmPassword = EditHashPassword;
            //res3.ConfirmPassword = EditHashPassword;

            admin.Edit(res3);

            return Redirect("/admin/Index");
        }


        public ActionResult logout()
        {
            Session.Remove("admin");
            return Redirect("/admin/login");
        }

        public ActionResult Delete_Admin(int id)
        {
            ////////////////////////////////
            if (Session["admin"] == null)
                return Redirect("/admin/login");
            ////////////////////////////////

            adminModel item2 = admin.GetAll().FirstOrDefault(i => i.id == id);
            if (item2.email == currentAdmin)
            {
                admin.Remove(id);
                return Redirect("/admin/login");
            }

            admin.Remove(id);
            TempData["alert"] = 3;
            return Redirect("/admin/Index");
        }
    }
}