using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SouqElGomalAdmin.ViewModels
{
    public class adminLoginModel
    {
        public string email { get; set; }
        public string pass { get; set; }
        public adminLoginModel(string ema, string pas)
        {
            email = ema;
            pass = pas;
        }
    }
}