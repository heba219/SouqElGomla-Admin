using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SouqElGomalAdmin.ViewModels
{
    public class ProductOrderModel
    {
        public int ID { set; get; }
        public int OrderID { set; get; }
        public int ProductID { set; get; }
        public int Quantity { set; get; }


        public ProductOrderModel()
        {

        }
        public ProductOrderModel(int _ID, int _OrderID, int _ProductID, int _Quantity)
        {
            ID = _ID;
            OrderID = _OrderID;
            ProductID = _ProductID;
            Quantity = _Quantity;
        }
    }
}