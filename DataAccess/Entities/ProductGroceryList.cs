using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class ProductGroceryList
    {
        [Key, Column(Order = 0)]
        public int ProductID { get; set; }
        [Key, Column(Order = 1)]
        public int GroceryListID { get; set; }

        public virtual Product Product { get; set; }
        public virtual GroceryList GroceryList { get; set; }

        public Boolean Tagged { get; set; }
    }
}
