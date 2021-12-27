using SouqElGomalAdmin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SouqElGomalAdmin.Repository
{
    public class OrderRepo
    {
        static List<OrderModel> resList = new List<OrderModel>();
        static API2SouqElGomlaEntities4 context = new API2SouqElGomlaEntities4();

        public static List<OrderModel> GetAll()
        {
            resList.Clear();
            foreach (var i in context.Orders)
            {
                resList.Add(new OrderModel(i.ID, i.UserId, i.OrderDate, i.ProductOrders, i.State));
            }

            return resList;

        }

        public static void Edit(OrderModel editOredr)
        {
            var x = context.Orders.Where(i => i.ID == editOredr.ID).FirstOrDefault();

            x.State = editOredr.State;

            context.SaveChanges();
        }

        //public static void Remove(int id)
        //{
        //    var y = context.Orders.Where(i => i.ID == id).FirstOrDefault();
        //    context.Orders.Remove(y);
        //    context.SaveChanges();
        //}
    }
}
