using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SouqElGomalAdmin.Models
{
    public class UserType
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public string UserName { get; set; }

        public string PhoneNumber { get; set; }

        //[Display(Name = "Upload Image")]
        //public byte[] Image { get; set; }
        //public HttpPostedFileBase ImageFile { get; set; }
    }
}