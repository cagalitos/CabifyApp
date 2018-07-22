using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopAPI.Models
{
    //This class represents the each of the items available to shop/scan.
    public class ShopItem
    {
        public int ItemId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public Promotion Promos { get; set; }
    }
}