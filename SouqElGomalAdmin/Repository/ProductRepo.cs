using SouqElGomalAdmin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SouqElGomalAdmin.Repository
{
    public class ProductRepo
    {
        static List<ProductModel> resList = new List<ProductModel>();
        static API2SouqElGomlaEntities1 context = new API2SouqElGomlaEntities1();

        public static List<ProductModel> GetAll()
        {
            resList.Clear();
            foreach (var i in context.Products)
            {
                resList.Add(new ProductModel(i.ID, i.Name,i.Description, (float)i.Price, i.Quantity, i.UnitWeight
                    , i.Image, i.UserId, (int)i.CategoryID));
            }

            return resList;

        }

        public static void Add(Product newProduct)
        {
            context.Products.Add(newProduct);
            context.SaveChanges();
        }

        public static void Edit(Product editedProduct)
        {
            var x = context.Products.Where(i => i.ID == editedProduct.ID).FirstOrDefault();
            x.Name = editedProduct.Name;
            x.Category = editedProduct.Category;
            x.Price = editedProduct.Price;
            x.Image = editedProduct.Image;
            x.ProductionDate = editedProduct.ProductionDate;
            x.UnitWeight = editedProduct.UnitWeight;

            context.SaveChanges();
        }

        public static void Remove(int id)
        {
            var y = context.Products.Where(i => i.ID == id).FirstOrDefault();
            context.Products.Remove(y);
            context.SaveChanges();
        }
    }
}