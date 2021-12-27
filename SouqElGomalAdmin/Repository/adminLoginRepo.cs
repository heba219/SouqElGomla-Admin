using SouqElGomalAdmin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SouqElGomalAdmin.Repository
{
    public class adminLoginRepo
    {
        static List<adminLoginModel> resList = new List<adminLoginModel>();
        static API2SouqElGomlaEntities4 context = new API2SouqElGomlaEntities4();
        static List<adminLoginModel> res7 = new List<adminLoginModel>();

        public static List<adminLoginModel> GetAll()
        {
            resList.Clear();
            foreach (var i in context.adminLogins)
            {
                var email = i.email;
                var password = i.password;       // to resolve Cashing problem

                resList.Add(new adminLoginModel(email, password));
            }

            return resList;
        }

        public static List<adminLoginModel> GetAllAfterEdit()
        {
            resList.Clear();
            foreach (var x in context.adminLogins)
            {
                var email = x.email;
                var password = x.password;       // to resolve Cashing problem

                res7.Add(new adminLoginModel(email, password));
            }

            return res7;
        }


        public void addAdmins(adminLogin newAdmin)
        {
            context.adminLogins.Add(newAdmin);
            context.SaveChanges();

        }
    }
}