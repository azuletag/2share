using DataAccess.Entities;
using Services;
using Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _2Share.Controllers
{
    public class GroceryController : ApiController
    {
        private IGroceryService GroceryService;

        public GroceryController()
        {
            this.GroceryService = new GroceryService();
        }
        [HttpGet]
        [ActionName("Products")]
        public IHttpActionResult GetProducts()
        {
            var products = this.GroceryService.GetProducts();
            if (products.Count() == 0)
            {
                return NotFound();
            }
            return Ok(products);
        }
        [HttpGet]
        public IHttpActionResult GroceryList()
        {
            var groceryList = this.GroceryService.GetGroceryList();
            if(groceryList == null)
            {
                return NotFound();
            }
            return Ok(groceryList);
        }

        [HttpPost]
        public IHttpActionResult GroceryList([FromBody] GroceryListViewModel groceryListViewModel)
        {
            IResponse response = this.GroceryService.UpdateGroceryList(groceryListViewModel);
            return Ok(response);
        }
    }
}
