using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SouqElGomalAdmin.ViewModels
{
    public class OrderModel
    {

        public int ID { set; get; }
        public string UserId { set; get; }
        public DateTime OrderDate { set; get; }
        public int State { set; get; }
        public int PaymentMethod { set; get; }
        public virtual ICollection<ProductOrder> ProductOrders { get; set; }



        public OrderModel()
        {

        }

        public OrderModel(int _ID, string _UserId, DateTime _OrderDate, ICollection<ProductOrder> _ProductOrders, int _State)
        {
            ID = _ID;
            UserId = _UserId;
            OrderDate = _OrderDate;
            ProductOrders = _ProductOrders;
            State = _State;
        }
    }
}