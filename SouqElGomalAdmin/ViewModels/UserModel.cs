using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SouqElGomalAdmin.ViewModels
{
    public class UserModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        
        public string UserName { get; set; }

        public string PhoneNumber { get; set; }


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