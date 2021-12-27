using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SouqElGomalAdmin.ViewModels
{
    public class HelpInOrder
    {
        public string NameOfProduct { get; set; }
        public int QuantityOfProduct { get; set; }
        public float PriceOfProduct { get; set; }
        public float TotalPriceOfProduct { get; set; }
    }
}