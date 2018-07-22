using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopAPI.Models;

namespace APIUnitTests
{

    //These tests check whether the logic of the promotions is working fine. 
    //They are taking from the github reporsitory shared with the test.

    [TestClass]
    public class APITests
    {

        private Promotion promoVouchers;
        private Promotion promoTshirts;
        private List<Promotion> promos = new List<Promotion>();

        public APITests()
        {

            //Find more information about these promotions in the promotions class

            promoVouchers = new Promotion
            {
                PromotionId = 1,
                ItemId = 1,
                IsXforY = true,
                XNumber = 2,
                YNumber = 1,
                Description = "2 for 1 promotion on vouchers",
                StartDate = DateTime.UtcNow.AddDays(-5),
                EndDate = DateTime.UtcNow.AddDays(5),
            };

            promoTshirts = new Promotion
            {
                PromotionId = 2,
                ItemId = 2,
                Description = "Discounted price on 3 or more T-Shirts",
                IsBulk = true,
                MinNumItems = 3,
                NewPrice = 19,
                StartDate = DateTime.UtcNow.AddDays(-5),
                EndDate = DateTime.UtcNow.AddDays(5),
            };

            promos.Add(promoVouchers);
            promos.Add(promoTshirts);
        }

        [TestMethod]
        public void NoPromotions()
        {

            Cart cart = new Cart(promos);

            cart.CartItems.Add(new CartItem { ItemId = 1, Code = "VOUCHER", Price = 5.00 });
            cart.CartItems.Add(new CartItem { ItemId = 2, Code = "TSHIRT", Price = 20.00 });
            cart.CartItems.Add(new CartItem { ItemId = 3, Code = "MUG", Price = 7.50 });

            Assert.IsTrue(cart.FinalTotal == 32.50);
            Assert.IsTrue(cart.Total == cart.FinalTotal);

        }

        [TestMethod]
        public void TwoForOnePromotion()
        {

            Cart cart = new Cart(promos);

            cart.CartItems.Add(new CartItem { ItemId = 1, Code = "VOUCHER", Price = 5.00 });
            cart.CartItems.Add(new CartItem { ItemId = 2, Code = "TSHIRT", Price = 20.00 });
            cart.CartItems.Add(new CartItem { ItemId = 1, Code = "VOUCHER", Price = 5.00 });

            Assert.IsTrue(cart.FinalTotal == 25);
            Assert.IsTrue(cart.Total == 30);

        }

        [TestMethod]
        public void BulkPromotion()
        {

            Cart cart = new Cart(promos);

            cart.CartItems.Add(new CartItem { ItemId = 2, Code = "TSHIRT", Price = 20.00 });
            cart.CartItems.Add(new CartItem { ItemId = 2, Code = "TSHIRT", Price = 20.00 });
            cart.CartItems.Add(new CartItem { ItemId = 2, Code = "TSHIRT", Price = 20.00 });
            cart.CartItems.Add(new CartItem { ItemId = 1, Code = "VOUCHER", Price = 5.00 });
            cart.CartItems.Add(new CartItem { ItemId = 2, Code = "TSHIRT", Price = 20.00 });

            Assert.IsTrue(cart.FinalTotal == 81);
            Assert.IsTrue(cart.Total == 85);

        }

        [TestMethod]
        public void BothPromotion()
        {

            Cart cart = new Cart(promos);

            cart.CartItems.Add(new CartItem { ItemId = 1, Code = "VOUCHER", Price = 5.00 });
            cart.CartItems.Add(new CartItem { ItemId = 2, Code = "TSHIRT", Price = 20.00 });
            cart.CartItems.Add(new CartItem { ItemId = 1, Code = "VOUCHER", Price = 5.00 });
            cart.CartItems.Add(new CartItem { ItemId = 1, Code = "VOUCHER", Price = 5.00 });
            cart.CartItems.Add(new CartItem { ItemId = 3, Code = "MUG", Price = 7.50 });
            cart.CartItems.Add(new CartItem { ItemId = 2, Code = "TSHIRT", Price = 20.00 });
            cart.CartItems.Add(new CartItem { ItemId = 2, Code = "TSHIRT", Price = 20.00 });

            Assert.IsTrue(cart.FinalTotal == 74.5);
            Assert.IsTrue(cart.Total == 82.5);

        }
    }
}
