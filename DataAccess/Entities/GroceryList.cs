using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class GroceryList
    {
        public int GroceryListID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ProductGroceryList> Products { get; set; }
    }
}
