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

        [Required(ErrorMessage = "*Name Required")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "*Description Required")]
        [Display(Name = "Description ")]
        public string Description { get; set; }

        [Required(ErrorMessage = "*Price Required")]
        [Display(Name = "Price")]
        public float Price { get; set; }

        [Required(ErrorMessage = "*Quantity Required")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "*UnitWeight Required")]
        [Display(Name = "UnitWeight")]
        public string UnitWeight { get; set; }


        [Display(Name = "Image")]
        public byte[]Image { get; set; }


        [Display(Name = "UserId")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "*Packges Number Required")]
        [Display(Name = "Packges Number")]
        public int PackgesNumber { get; set; }

        [Required(ErrorMessage = "*Category Required")]
        public int CategoryID { get; set; }


        public ProductModel()
        {

        }
        public ProductModel(int _id, string _name, string _Description, float _Price , string _UnitWeight, byte[] _Image
            ,  int _CategoryID = 0)
        {
            Name = _name;
            ID = _id;
            Description = _Description;
            Price = _Price;
            Image = _Image;
            CategoryID = _CategoryID;
            UnitWeight = _UnitWeight;
        }
    }
}