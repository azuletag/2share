using DataAccess.Entities;
using Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IGroceryService : IDisposable
    {
        IResponse UpdateGroceryList(GroceryListViewModel groceryList);
        IEnumerable<Product> GetProducts();
        GroceryList GetGroceryList();
    }
}
