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
        [Required(ErrorMessage = "*Name Required")]
        public string Name { get; set; }

        //[Display(Name = "Quantity Of Products")]
        //public int QuantityOfProducts { get; set; }

        [Display(Name = "Description ")]
        [Required(ErrorMessage = "*Description Required")]
        public string Description { get; set; }

        [Display(Name = "Image ")]
        public byte[] Image { get; set; }

        public ICollection<Product> Products { get; set; }


        public CategoryModel()
        {

        }

        public CategoryModel(int id, string name, ICollection<Product> _Products, string _Description, byte[] _Image)
        {
            Name = name;
            ID = id;
            Products = _Products;
            Description = _Description;
            Image = _Image;
        }
    }
}