//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SouqElGomalAdmin
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class adminLogin
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
        public string ConfirmPassword { get; set; } // plus

        [Required(ErrorMessage = "*Mobile Required")]
        [StringLength(11, ErrorMessage = "*Mobile NOT Valid")]
        public string mobile { get; set; }
    }
}
