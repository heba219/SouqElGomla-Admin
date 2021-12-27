using SouqElGomalAdmin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SouqElGomalAdmin.Repository
{
    public class ProductOrderRepo
    {
        static List<ProductOrderModel> resList = new List<ProductOrderModel>();
        static API2SouqElGomlaEntities4 context = new API2SouqElGomlaEntities4();

        public static List<ProductOrderModel> GetAll()
        {
            resList.Clear();
            foreach (var i in context.ProductOrders)
            {
                resList.Add(new ProductOrderModel(i.ID, i.OrderID, i.ProductID, i.Quantity));
            }

            return resList;

        }

        //public static void Edit(ProductOrder editedProductOrder)
        //{
        //    var x = context.ProductOrders.Where(i => i.ID == editedProductOrder.ID).FirstOrDefault();

        //    x.State = editedProductOrder.State;

        //    context.SaveChanges();
        //}
    }
}