using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IGroceryRepository
    {
        void UpdateGroceryList(GroceryList groceryList);
        IEnumerable<Product> GetProducts();
        void Save();
        GroceryList GetGroceryList();
    }
}
