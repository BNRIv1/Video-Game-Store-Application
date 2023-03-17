using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IT_MVC_Proekt.Models
{
    public class Game
    {
        //List page
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "List View Image")]
        public string ImageURL { get; set; }
        [Display(Name = "List View Description")]
        public string Description { get; set; }
        public string Genre { get; set; }
        public string Developer { get; set; }
        public string Date { get; set; }
        public double Price { get; set; }

        //Description Page
        [Display(Name = "Details View Description")]
        public string LongDesc { get; set; }
        
        [Display(Name = "Details View Image")]
        public string DescImg { get; set; }
        [Display(Name = "Screenshot 1")]
        public string Screenshot1 { get; set; }
        [Display(Name = "Screenshot 2")]
        public string Screenshot2 { get; set; }
        [Display(Name = "Screenshot 3")]
        public string Screenshot3 { get; set; }

    }
}