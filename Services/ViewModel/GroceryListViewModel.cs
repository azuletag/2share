using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ViewModel
{
    public class GroceryListViewModel
    {
        public int GroceryListId { get; set; }
        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}
