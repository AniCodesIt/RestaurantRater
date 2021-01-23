using RestaurantRater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestaurantRater.Controllers
{
    public class RestaurantController : ApiController
    {
        private readonly RestaurantDbContext _context = new RestaurantDbContext();
        //POST (create)
        //api/Restaurant
        [HttpPost]
        public async Task <IHttpActionResult> CreateRestaurant([FromBody]Restaurant model)
        {
            if (ModelState.IsValid)
            {
                //Store the model in the database
                _context.Restaurants.Add(model);
               int changeCount = await _context.SaveChangesAsync();
                
                return Ok("Restaurant created! ");
            }
            //The model is not valid, reject it
            return BadRequest(ModelState);
        }
    }
}
