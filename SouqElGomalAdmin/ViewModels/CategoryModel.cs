using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SouqElGomalAdmin.Models
{
    public class CategoryModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int QuantityOfProducts { get; set; }


        public CategoryModel(int id, string name, int Quantity)
        {
            Name = name;
            ID = id;
            QuantityOfProducts = Quantity;
        }
    }
}