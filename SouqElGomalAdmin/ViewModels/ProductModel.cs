using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SouqElGomalAdmin.ViewModels
{
    public class ProductModel
    {
        [Display(Name = "ID")]
        public int ID { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Description ")]
        public string Description { get; set; }
        [Display(Name = "Price")]
        public float Price { get; set; }
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
        [Display(Name = "UnitWeight")]
        public string UnitWeight { get; set; }
        [Display(Name = "Image")]
        public byte[]Image { get; set; }
        [Display(Name = "UserId")]
        public string UserId { get; set; }

        public int CategoryID { get; set; }


        public ProductModel()
        {

        }
        public ProductModel(int _id, string _name, string _Description, float _Price, int _Quantity
            , string _UnitWeight, byte[] _Image, string _UserId, int _CategoryID)
        {
            Name = _name;
            ID = _id;
            Description = _Description;
            Price = _Price;
            Quantity = _Quantity;
            UnitWeight = _UnitWeight;
            Image = _Image;
            UserId = _UserId;
            CategoryID = _CategoryID;
        }
    }
}