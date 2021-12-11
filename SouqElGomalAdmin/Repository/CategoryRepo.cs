using SouqElGomalAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SouqElGomalAdmin.Repository
{
    public class CategoryRepo
    {
        static List<CategoryModel> resList = new List<CategoryModel>();


        public static List<CategoryModel> GetAll()
        {
            APISouqElGomlaEntities context = new APISouqElGomlaEntities();


            foreach (var i in context.Categories)
            {
                resList.Add(new CategoryModel(i.ID, i.Name, i.Products.Count));
            }

            return resList;

        }

    }
}