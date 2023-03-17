using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IT_MVC_Proekt.Models
{
    public class PurchasedProduct
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string ImageURL { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public string Developer { get; set; }
        public string Date { get; set; }
        public double Price { get; set; }
        public string LongDesc { get; set; }
        public string DescImg { get; set; }
        public string Screenshot1 { get; set; }
        public string Screenshot2 { get; set; }
        public string Screenshot3 { get; set; }

    }
}