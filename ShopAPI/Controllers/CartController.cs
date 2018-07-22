using ShopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ShopAPI.Controllers
{

    [RoutePrefix("api/cart")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CartController : ApiController
    {

        //This returns a cart object with the items selected by the user.
        [Route("")]
        [HttpPost]
        public IHttpActionResult UpdateCart([FromBody] List<ShopItem> items)
        {
            //A cart object is created which requires the promotions (or pricing rules).
            // Within the cart, promotions are applied to calculate the total. Go to the 
            // cart object and to see how the finalTotal (the one with the promotions applied)
            // is calculated.
            Cart cart = new Cart(Promotion.GetPromotions());
            int i = 1;

            foreach (ShopItem si in items)
            {
                cart.CartItems.Add(new CartItem {
                    CartItemId = i,
                    ItemId = si.ItemId,
                    Code = si.Code,
                    Description = si.Description,
                    Price = si.Price
                });

                i++;
            }

            return Ok(cart);
        }

    }
}
