using SouqElGomalAdmin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace SouqElGomalAdmin.Repository
{
    public class admin
    {
        public static API2SouqElGomlaEntities4 context = new API2SouqElGomlaEntities4();
        public static List<adminModel> resList = new List<adminModel>();
        public static List<adminModel> GetAll()
        {

            resList.Clear();
            foreach (var i in context.adminLogins)
            {
                resList.Add(new adminModel(i.id, i.name, i.password, i.Address, i.email, i.mobile));
            }

            return resList;

        }

        public static void Remove(int id)
        {
            var y = context.adminLogins.Where(i => i.id == id).FirstOrDefault();
            context.adminLogins.Remove(y);
            context.SaveChanges();
        }

        public static void Edit(adminLogin editedAdmin)
        {
            var x = context.adminLogins.Where(i => i.id == editedAdmin.id).FirstOrDefault();

            x.id = editedAdmin.id;
            x.name = editedAdmin.name;
            x.password = editedAdmin.password;
            x.ConfirmPassword = editedAdmin.ConfirmPassword;
            x.email = editedAdmin.email;
            x.mobile = editedAdmin.mobile;
            x.Address = editedAdmin.Address;

            context.SaveChanges();
        }
    }
}