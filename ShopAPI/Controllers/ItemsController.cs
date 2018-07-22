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

    [RoutePrefix("api/items")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ItemsController : ApiController
    {

        //Gets a list of all items that can be bought/scanned their relevant promotions.
        [Route("")]
        [HttpGet]
        public IHttpActionResult Get()
        {

            List<Promotion> promos = Promotion.GetPromotions();

            //Ideally these would be stored in a Database and retrieved using entitites. Since I am not sure I can send you
            //a project with a localDB you can run, I have decided to hardcode these items here, but I do understand this
            //is not correct as this would require to redeploy if a new item is to be added.

            List<ShopItem> items = new List<ShopItem>();

            items.Add(new ShopItem { ItemId = 1, Code = "VOUCHER", Description = "Cabify Voucher", Price = 5.00 });
            items.Add(new ShopItem { ItemId = 2, Code = "TSHIRT", Description = "Cabify T-Shirt", Price = 20.00 });
            items.Add(new ShopItem { ItemId = 3, Code = "MUG", Description = "Cabify Coffee Mug", Price = 7.50 });

            foreach (ShopItem item in items)
            {
                item.Promos = promos.Where(z => z.ItemId == item.ItemId).FirstOrDefault();
            }

            return Ok(items);
        }

    }
}
