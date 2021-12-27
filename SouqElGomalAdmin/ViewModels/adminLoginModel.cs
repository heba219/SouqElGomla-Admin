using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SouqElGomalAdmin.ViewModels
{
    public class adminLoginModel
    {
        [Required(ErrorMessage = "*Email Required")]
        public string email { get; set; }
        [Required(ErrorMessage = "*Password Required")]
        public string pass { get; set; }

        public adminLoginModel()
        {

        }
        public adminLoginModel(string ema, string pas)
        {
            email = ema;
            pass = pas;
        }
    }
}