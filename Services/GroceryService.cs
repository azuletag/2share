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
    public class GroceryService : IGroceryService
    {
        private IGroceryRepository GroceryRepository;

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
    }
}
