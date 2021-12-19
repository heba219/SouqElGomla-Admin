using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SouqElGomalAdmin.ViewModels
{
    public class UserModel
    {
        [Display(Name = "ID")]
        public string ID { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "UserName")]
        public string UserName { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Upload Image")]
        public byte[] Image { get; set; }
        public UserModel()
        {

        }
        public UserModel(string _id, string _name, string _Address, string _Email, string _UserName, string _PhoneNumber)
        {
            Name = _name;
            ID = _id;
            Address = _Address;
            Email = _Email;
            UserName = _UserName;
            PhoneNumber = _PhoneNumber;
        }
    }
}