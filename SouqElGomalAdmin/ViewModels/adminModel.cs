using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SouqElGomalAdmin.ViewModels
{
    public class adminModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "*Name Required")]
        public string name { get; set; }
        [Required(ErrorMessage = "*Address Required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "*Email Required")]
        public string email { get; set; }
        [Required(ErrorMessage = "*Password Required")]
        public string password { get; set; }
        [Required(ErrorMessage = "*Confirm Password Required")]
        public string Confirmpassword { get; set; }
        [Required(ErrorMessage = "*Mobile Required")]
        [StringLength(11, ErrorMessage = "*Mobile NOT Valid")] public string mobile { get; set; }
        public adminModel()
        { }
        public adminModel(int _id, string _name, string _password, string _Address, string _email, string _mobile)
        {
            id = _id;
            name = _name;
            password = _password;
            Address = _Address;
            email = _email;
            mobile = _mobile;
        }


    }
}