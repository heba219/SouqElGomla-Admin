using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SouqElGomalAdmin.ViewModels;

namespace SouqElGomalAdmin.Repository
{
    public class UserRepo
    {

        static List<UserModel> resList = new List<UserModel>();


        public static List<UserModel> GetAll()
        {
            APISouqElGomlaEntities context = new APISouqElGomlaEntities();


            foreach (var i in context.Users)
            {
                resList.Add(new UserModel(i.Id, i.Name, i.Address,i.Email, i.UserName, i.PhoneNumber ));
            }

            return resList;

        }
    }
}