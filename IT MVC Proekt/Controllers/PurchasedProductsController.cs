using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IT_MVC_Proekt.Models;
using Microsoft.AspNet.Identity;

namespace IT_MVC_Proekt.Controllers
{
    [Authorize]
    public class PurchasedProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PurchasedProducts
        public ActionResult Index()
        {
            string UserId = User.Identity.GetUserId();
            return View(db.purchasedProducts.Where(product => product.UserId.Equals(UserId)).ToList());
        }

        public ActionResult Create(int? id, string returnURL)
        {
            var game = db.games.Find(id);
            string UserId = User.Identity.GetUserId();
            if (db.purchasedProducts.Where(product => product.UserId.Equals(UserId)).ToList().Exists(product => product.GameId == id))
            {
                return Redirect(returnURL);
            }
            else
            {
                PurchasedProduct purchasedProduct = new PurchasedProduct();
                purchasedProduct.GameId = game.Id;
                purchasedProduct.UserId = User.Identity.GetUserId();
                purchasedProduct.ImageURL = game.ImageURL;
                purchasedProduct.Name = game.Name;
                purchasedProduct.Description = game.Description;
                purchasedProduct.Price = game.Price;
                purchasedProduct.Genre = game.Genre;
                purchasedProduct.Developer = game.Developer;
                purchasedProduct.Date = game.Date;
                purchasedProduct.Screenshot1 = game.Screenshot1;
                purchasedProduct.Screenshot2 = game.Screenshot2;
                purchasedProduct.Screenshot3 = game.Screenshot3;
                purchasedProduct.LongDesc = game.LongDesc;
                purchasedProduct.DescImg = purchasedProduct.DescImg;

                db.purchasedProducts.Add(purchasedProduct);
                db.SaveChanges();
                return Redirect(returnURL);
            }
            
        }

        public ActionResult Delete(int? id)
        {
            PurchasedProduct purchasedProduct = db.purchasedProducts.Find(id);
            db.purchasedProducts.Remove(purchasedProduct);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult EmptyCart()
        {
            string UserId = User.Identity.GetUserId();
            var products = db.purchasedProducts.Where(product => product.UserId.Equals(UserId)).ToList();
            db.purchasedProducts.RemoveRange(products);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
