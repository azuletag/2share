using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    
    public class GroceryRepository : IGroceryRepository, IDisposable
    {
        private GroceryContext context;

        public GroceryRepository(GroceryContext context)
        {
            this.context = context;
        }
        public void UpdateGroceryList(GroceryList groceryList)
        {
            var oldGroceryList = context.GroceryLists.Find(groceryList.GroceryListID);

            foreach (var product in groceryList.Products.ToList())
            {
                // Add the products which are not in the list of grocery list
                if (!oldGroceryList.Products.Any(x => x.ProductID == product.ProductID))
                {
                    var newProduct = new ProductGroceryList 
                                     { 
                                        ProductID = product.ProductID,
                                        GroceryListID = product.GroceryListID,
                                        Tagged = product.Tagged
                                     };
                    oldGroceryList.Products.Add(newProduct);
                }
                else
                {


                    try
                    {
                        var changedTagProduct = oldGroceryList.Products.SingleOrDefault(x => x.ProductID == product.ProductID &&
                                                                        x.Tagged != product.Tagged);

                        if (changedTagProduct != null)
                        {
                            changedTagProduct.Tagged = product.Tagged;
                            context.Entry(changedTagProduct).State = EntityState.Modified;
                        }
                    }
                    catch (InvalidOperationException ex)
                    {
                        //More then one value returned by single or default.
                        //Operation cant continue, service must handle the exception
                        throw;
                    }

                }
            }

            foreach (var product in oldGroceryList.Products.ToList())
            {
                //Remove products which are not in the new grocery list
                if (!groceryList.Products.Any(x => x.ProductID == product.ProductID))
                    oldGroceryList.Products.Remove(product);
                
            }

        }
        
        public IEnumerable<Product> GetProducts()
        {
            IEnumerable<Product> products = new List<Product>();
            try
            {
                return context.Products.ToList();
            }
            catch(Exception ex)
            {
                //Loggging here
            }
            return products;
        }

        public GroceryList GetGroceryList()
        {
            return context.GroceryLists.FirstOrDefault();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
