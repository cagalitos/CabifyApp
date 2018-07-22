using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopAPI.Models
{
    //This class represents the user cart (i.e. the list of items that have been scanned and their final price after
    //promotions are applied. Should there be no promotions, then the Final and total price will be the same.
    public class Cart
    {
        private List<Promotion> _promos;
        List<CartItem> _cart = new List<CartItem>();
        public Cart(List<Promotion> promos)
        {
            _promos = promos ?? new List<Promotion>();
        }
        public List<CartItem> CartItems { get { return CalculatePromotions(); } set { _cart = value; } }

        //This property returns the raw price sum of all items, without any promotions applied.
        public double Total { get { return _cart.Sum(x => x.Price); } }

        //This property returns the discounted price sum of all items, with the promotions applied.
        //At the moment there are two types of promotions (bulk and XforY promotions). This can be 
        //extended to further types of promotions (% discounts for example).
        public double FinalTotal { get { return _cart.Sum(x => x.FinalPrice); } }


        private List<CartItem> CalculatePromotions()
        {
            //First we set the both prices to the normal non-discounted price to start clean.
            _cart.Select(c => { c.FinalPrice = c.Price; return c; }).ToList();

            foreach (Promotion promotion in _promos)
            {
                //We get the number of items that fall within the promotion
                int promoItemsCount = _cart.Where(p => p.ItemId == promotion.ItemId).Count();

                if (promotion.IsBulk)
                {
                    //The MinNumItems will give us how many items we need at least to apply the new price
                    if (promoItemsCount >= promotion.MinNumItems)
                    {
                        //For all items that fall within the promotion, we apply the new price and attach the promotion information
                        _cart.Where(p => p.ItemId == promotion.ItemId)
                            .Select(c =>
                            {
                                c.FinalPrice = promotion.NewPrice;
                                c.IsPromoted = true;
                                c.PromotionDescription = promotion.Description;
                                return c;
                            }).ToList();
                    }

                }
                else if (promotion.IsXforY)
                {
                    //Xnumber is the first part in an XforY promotion (5 for 3, x = 5, y = 3)
                    //This logic will work on any XforY promotion.
                    if (promoItemsCount >= promotion.XNumber)
                    {
                        //We get the int of the division as we want to know how many of X we have in the list of promoted items.
                        //For example, if we have seven items in a 2for1 promo, only 6 are affected.
                        int numberOfPromoted = promoItemsCount / promotion.XNumber;
                        int skip = 0;

                        //We look on each group of X. For each of teh groups, the first Y items maintain the full price
                        //but all other items get their price updated to 0 (free) and get marked as promoted.
                        for (int i = 0; i < numberOfPromoted; i++)
                        {
                            int count = _cart.Where(p => p.ItemId == promotion.ItemId).Skip(skip).Take(promotion.XNumber).Count();

                            for (int t = 0; t < count; t++)
                            {
                                if (t >= promotion.YNumber)
                                {
                                    _cart.Where(p => p.ItemId == promotion.ItemId)
                                        .Skip(skip).Take(promotion.XNumber).ToList()[t].FinalPrice = 0;

                                    _cart.Where(p => p.ItemId == promotion.ItemId)
                                        .Skip(skip).Take(promotion.XNumber).ToList()[t].IsPromoted = true;

                                    _cart.Where(p => p.ItemId == promotion.ItemId)
                                        .Skip(skip).Take(promotion.XNumber).ToList()[t].PromotionDescription = promotion.Description;

                                }
                            }

                            skip += promotion.XNumber;

                        }
                    }
                }
            }

            return _cart;
        }
    }
}