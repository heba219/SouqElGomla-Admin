using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SouqElGomalAdmin.ViewModels;

namespace SouqElGomalAdmin.Repository
{
    public class UserRepo
    {

        static List<UserModel> resList = new List<UserModel>();
        static API2SouqElGomlaEntities4 context = new API2SouqElGomlaEntities4();

        public static List<UserModel> GetAll()
        {
            
            resList.Clear();
            foreach (var i in context.AspNetUsers)
            {
                resList.Add(new UserModel(i.Id, i.Name, i.Address,i.Email, i.UserName, i.PhoneNumber));
            }

            return resList;

        }

        public static void Add(AspNetUser newUser)
        {
            context.AspNetUsers.Add(newUser);
            context.SaveChanges();
        }


        public static void Edit(AspNetUser editedUser)
        {
            var x = context.AspNetUsers.Where(i => i.Id == editedUser.Id).FirstOrDefault();
            x.Name = editedUser.Name;
            x.Address = editedUser.Address;
            x.Email = editedUser.Email;
            x.UserName = editedUser.UserName;
            x.PhoneNumber = editedUser.PhoneNumber;

            context.SaveChanges();
        }


        public static void Remove(string id)
        {
            var y = context.AspNetUsers.Where(i => i.Id== id).FirstOrDefault();
            context.AspNetUsers.Remove(y);
            context.SaveChanges();
        }


    }
}