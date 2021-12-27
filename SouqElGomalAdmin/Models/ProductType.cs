using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SouqElGomalAdmin.Models
{
    public class ProductType
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
        [Required(ErrorMessage = "*Image Required")]
        public byte[] Image { get; set; }


        [Display(Name = "UserId")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "*Category Required")]
        public int CategoryID { get; set; }

    }
}