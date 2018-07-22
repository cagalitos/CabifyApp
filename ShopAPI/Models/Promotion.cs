using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopAPI.Models
{
    //This class holds the promotions. At the moment is configured to describe two types of promotions
    //ItemId Relates to the shopItemId
    public class Promotion
    {
        public int PromotionId { get; set; }
        public int ItemId { get; set; }
        public string Description { get; set; }
        public bool IsXforY { get; set; }
        public int XNumber { get; set; }
        public int YNumber { get; set; }
        public bool IsBulk { get; set; }
        public int MinNumItems { get; set; }
        public double Discount { get; set; }
        public double NewPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public static List<Promotion> GetPromotions()
        {

            //Ideally these would be stored in a Database and retrieved using entitites. Since I am not sure I can send you
            //a project with a localDB you can run, I have decided to hardcode these promotions here, but I do understand this
            //is not correct as this would require to redeploy if a new promotion is to be added.
            List<Promotion> promos = new List<Promotion>();

            promos.Add(new Promotion
            {
                PromotionId = 1,
                ItemId = 1,
                IsXforY = true,
                XNumber = 2,
                YNumber = 1,
                Description = "2 for 1 promotion on vouchers",
                StartDate = DateTime.UtcNow.AddDays(-5),
                EndDate = DateTime.UtcNow.AddDays(5),
            });

            promos.Add(new Promotion
            {
                PromotionId = 2,
                ItemId = 2,
                Description = "Discounted price on 3 or more T-Shirts",
                IsBulk = true,
                MinNumItems = 3,
                NewPrice = 19,
                StartDate = DateTime.UtcNow.AddDays(-5),
                EndDate = DateTime.UtcNow.AddDays(5),
            });

            //This is just an example of another offer that can be added so you can see how the logic works
            //for other promotions as well
            //promos.Add(new Promotion
            //{
            //    PromotionId = 3,
            //    ItemId = 3,
            //    IsXforY = true,
            //    XNumber = 5,
            //    YNumber = 3,
            //    Description = "5 for 3 promotion on mugs",
            //    StartDate = DateTime.UtcNow.AddDays(-5),
            //    EndDate = DateTime.UtcNow.AddDays(5),
            //});

            //Returns only the ones that are active. Since I do not know when you will be running this code, I used
            //DateTime UTC now so that when you run it both promotions are active.
            return promos.Where(x => x.StartDate <= DateTime.UtcNow && x.EndDate >= DateTime.UtcNow).ToList();
        }

    }


}