using SouqElGomalAdmin.Models;
using SouqElGomalAdmin.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SouqElGomalAdmin.Repository
{
    public class CategoryRepo
    {
        static List<CategoryModel> resList = new List<CategoryModel>();
        static API2SouqElGomlaEntities1 context = new API2SouqElGomlaEntities1();

        public static List<CategoryModel> GetAll()
        {
            resList.Clear();
            foreach (var i in context.Categories)
            {
                resList.Add(new CategoryModel(i.ID, i.Name, i.Products.Count,i.Description, i.Image));
            }

            return resList;

        }

        public static void Add(Category newCategory)
        {
            context.Categories.Add(newCategory);
            context.SaveChanges();
        }


        public static void Edit(Category editedCategory)
        {
            var x = context.Categories.Where(i => i.ID == editedCategory.ID).FirstOrDefault();

            x.Name = editedCategory.Name;
            x.Description = editedCategory.Description;
            x.Image= editedCategory.Image;

            context.SaveChanges();
        }

        public static void Remove(int id)
        {
            var y = context.Categories.Where(i => i.ID == id).FirstOrDefault();
            context.Categories.Remove(y);
            context.SaveChanges();
        }

    }
}