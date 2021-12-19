using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SouqElGomalAdmin.ViewModels
{
    public class CategoryModel
    {
        [Display(Name = "ID")]
        public int ID { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Quantity Of Products")]
        public int QuantityOfProducts { get; set; }
        [Display(Name = "Description ")]
        public string Description { get; set; }
        [Display(Name = "Image ")]
        public byte[] Image { get; set; }


        public CategoryModel()
        {

        }

        public CategoryModel(int id, string name, int Quantity, string _Description, byte[] _Image)
        {
            Name = name;
            ID = id;
            QuantityOfProducts = Quantity;
            Description = _Description;
            Image = _Image;
        }
    }
}