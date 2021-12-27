using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SouqElGomalAdmin.Models
{
    public class CategoryType
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
    }
}