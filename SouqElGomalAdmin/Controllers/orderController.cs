using PagedList;
using SouqElGomalAdmin.Repository;
using SouqElGomalAdmin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SouqElGomalAdmin.Controllers
{
    public class orderController : Controller
    {
        List<ProductOrderModel> productsOrderID = new List<ProductOrderModel>();
        List<HelpInOrder> productsOrder = new List<HelpInOrder>();
        float TotalPrice =0;

        // GET: order
        public ActionResult Index(int? page, string SearchBy = "ID", string Search = "")
        {
            ////////////////////////////////
            if (Session["admin"] == null)
                return Redirect("/admin/login");
            ////////////////////////////////
            ///

            List<OrderModel> res = new List<OrderModel>();

            if (SearchBy == "ID")
            {
                if (Search == "")
                {
                    res = OrderRepo.GetAll().ToList();
                }
                else
                {
                    res = OrderRepo.GetAll().Where(i => i.ID == int.Parse(Search)).ToList();
                }
            }

            return View(res.ToPagedList(page ?? 1, 7));
        }





        public ActionResult Order_details(int ID)
        {
            ////////////////////////////////
            if (Session["admin"] == null)
                return Redirect("/admin/login");
            ////////////////////////////////

            OrderModel res = OrderRepo.GetAll().FirstOrDefault(i => i.ID == ID);
            UserModel temp4 = UserRepo.GetAll().FirstOrDefault(z => z.ID == res.UserId);

            foreach (var i in res.ProductOrders)
            {
                ProductOrderModel val = new ProductOrderModel();
                val.ProductID  = i.ProductID;
                val.Quantity = i.Quantity;
                val.ID = i.ID;
                productsOrderID.Add(val);
            }

            foreach (var i in productsOrderID)
            {
                HelpInOrder temp = new HelpInOrder();
                ProductModel temp2 = ProductRepo.GetAll().FirstOrDefault(x => x.ID == i.ProductID);
                ProductOrderModel temp3 = ProductOrderRepo.GetAll().FirstOrDefault(y => y.ProductID == temp2.ID);
                

                temp.NameOfProduct = temp2.Name;
                temp.PriceOfProduct = temp2.Price;
                temp.QuantityOfProduct = temp3.Quantity;
                temp.TotalPriceOfProduct = temp.QuantityOfProduct * temp.PriceOfProduct;
                TotalPrice += temp.TotalPriceOfProduct;

                productsOrder.Add(temp);
 
            }


            ViewBag.User = temp4;
            TempData["TotalPrice"] = TotalPrice;
            TempData["Prod"] = productsOrder;
            return View(res);
        }


        public ActionResult Accepted(OrderModel editOredr)
        {
            ////////////////////////////////
            if (Session["admin"] == null)
                return Redirect("/admin/login");
            ////////////////////////////////
            ///

            editOredr.State = 1;
            OrderRepo.Edit(editOredr);

            return Redirect("/order/Index");
        }
        public ActionResult Deliverd(OrderModel editOredr)
        {
            ////////////////////////////////
            if (Session["admin"] == null)
                return Redirect("/admin/login");
            ////////////////////////////////
            ///

            editOredr.State = 2;
            OrderRepo.Edit(editOredr);

            return Redirect("/order/Index");
        }
    }
}