using DataAccess;
using DataAccess.Entities;
using Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    /// <summary>
    /// Grocery list database repository class, exposing the required operations
    /// in a database based on the given context in its constructor.
    /// </summary>
    public class GroceryService : IGroceryService, IDisposable
    {
        
        private IGroceryRepository GroceryRepository;
        bool disposed;

        public GroceryService()
        {
            var context = new GroceryContext();
            this.GroceryRepository = new GroceryRepository(context);
        }

        public IResponse UpdateGroceryList(GroceryListViewModel groceryList)
        {
            // Convertion for groceryList view model object to a POCO groceryList object
            GroceryList groceryListUpdated = new GroceryList
            {
                GroceryListID = groceryList.GroceryListId,
                Products = groceryList.Products.Select(x => new ProductGroceryList
                {
                    ProductID = x.ProductId,
                    Tagged = x.Tagged,
                }).ToList()
            };

            try
            {
                this.GroceryRepository.UpdateGroceryList(groceryListUpdated);
                this.GroceryRepository.Save();
                return new Response("0", "Success");
            }
            catch(Exception ex)
            {
                //Logging exception and return an error response
            }

            return new Response("1", "Error updating grocery list.");
        }

        public IEnumerable<Product> GetProducts()
        {
            return this.GroceryRepository.GetProducts();
        }

        public GroceryList GetGroceryList()
        {
            return this.GroceryRepository.GetGroceryList();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    //dispose managed resources}
                    this.GroceryRepository.Dispose();
                }
            }
            //dispose unmanaged resources
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
