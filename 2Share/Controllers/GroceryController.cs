using DataAccess.Entities;
using Services;
using Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace _2Share.Controllers
{
    /// <summary>
    /// Controller used to route to the request operations on grocery list and products
    /// to the required services.
    /// </summary>

    [EnableCors(origins: "*", headers: "*", methods: "*")] //Enabling CORS for this controller.
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
        [HttpGet]
        [Route("")]
        public HttpResponseMessage Index()
        {
            var response = new HttpResponseMessage();
            response.Content = new StringContent("<div>Api is running</div>");
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            return response;
        }

        protected override void Dispose(bool disposing)
        {
            GroceryService.Dispose();
            base.Dispose(disposing);
        }
    }
}
