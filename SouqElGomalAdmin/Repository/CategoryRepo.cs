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
        static API2SouqElGomlaEntities4 context = new API2SouqElGomlaEntities4();

        public static List<CategoryModel> GetAll()
        {
            resList.Clear();
            resList.Clear();

            foreach (var i in context.Categories)
            {
                i.Products = context.Products.Where(j => j.CategoryID == i.ID).ToList();            // to resolve Cashing problem
                resList.Add(new CategoryModel(i.ID, i.Name, i.Products ,i.Description, i.Image));
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