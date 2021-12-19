using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SouqElGomalAdmin.Models
{
    public class ProductType
    {

        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Description ")]
        public string Description { get; set; }
        [Display(Name = "Price")]
        public float Price { get; set; }
        [Display(Name = "CategoryID")]
        public int CategoryID { get; set; }
        [Display(Name = "UnitWeight")]
        public string UnitWeight { get; set; }
        [Display(Name = "Image")]
        public byte[] Image { get; set; }
    }
}