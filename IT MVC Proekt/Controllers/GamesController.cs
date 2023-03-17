using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IT_MVC_Proekt.Models;
using PagedList;
using Microsoft.AspNet.Identity;
using System.Diagnostics;

namespace IT_MVC_Proekt.Controllers
{
    public class GamesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Games
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Games(string searchString, string currentFilter, int? page)
        {

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            var games = from game in db.games select game;
            if (!String.IsNullOrEmpty(searchString))
            {
                games = games.Where(g => g.Name.Contains(searchString));
            }
            
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            return View(games.OrderBy(i => i.Id).ToPagedList(pageNumber, pageSize));

        }

        // GET: Games/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // GET: Games/Create
        [Authorize(Roles = "Administrator,Publisher")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator,Publisher")]
        public ActionResult Create([Bind(Include = "Id,Name,ImageURL,Description,Genre,Developer,Date,Price,LongDesc,DescImg,Screenshot1,Screenshot2,Screenshot3")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.games.Add(game);
                db.SaveChanges();
                return RedirectToAction("Games");
            }

            return View(game);
        }

        // GET: Games/Edit/5
        [Authorize(Roles = "Administrator,Publisher")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator,Publisher")]
        public ActionResult Edit([Bind(Include = "Id,Name,ImageURL,Description,Genre,Developer,Date,Price,LongDesc,DescImg,Screenshot1,Screenshot2,Screenshot3")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Entry(game).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Games");
            }
            return View(game);
        }

        public ActionResult Delete(int id)
        {
            Game game = db.games.Find(id);
            db.games.Remove(game);
            db.SaveChanges();
            return RedirectToAction("Games");
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
