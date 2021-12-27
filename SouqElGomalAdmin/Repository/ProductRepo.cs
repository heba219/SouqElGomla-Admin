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
        static API2SouqElGomlaEntities4 context = new API2SouqElGomlaEntities4();

        public static List<ProductModel> GetAll()
        {
            resList.Clear();
            foreach (var i in context.Products)
            {
                ProductModel pro = new ProductModel();
                pro.ID = i.ID;
                pro.Name = i.Name;
                pro.Price = (float)i.Price;

                if(i.Quantity == null)
                {
                    pro.Quantity = 0;
                }
                else
                {
                    pro.Quantity = (int)i.Quantity;
                }
                    
                pro.Image = i.Image;

                if (i.CategoryID == null)
                {
                    pro.CategoryID = 0;
                }
                else
                {
                    pro.CategoryID = (int)i.CategoryID;
                }
                
                pro.Description = i.Description;
                pro.UnitWeight = i.UnitWeight;
                pro.PackgesNumber = (int)i.PackgesNumber;

                resList.Add(pro);
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
            x.Quantity = editedProduct.Quantity;

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