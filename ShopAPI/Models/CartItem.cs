using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopAPI.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public int ItemId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public bool IsPromoted { get; set; }
        public string PromotionDescription { get; set; }
        public double FinalPrice { get; set; }
    }
}