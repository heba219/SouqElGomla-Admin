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
        static API2SouqElGomlaEntities1 context = new API2SouqElGomlaEntities1();

        public static List<adminLoginModel> GetAll()
        {
            resList.Clear();
            foreach (var i in context.adminLogins)
            {
                resList.Add(new adminLoginModel(i.email, i.password));
            }

            return resList;

        }

        public void addAdmins(adminLogin newAdmin)
        {
            context.adminLogins.Add(newAdmin);
            context.SaveChanges();

        }
    }
}