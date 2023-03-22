using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Zerohunger.EF;

namespace Zerohunger.Controllers
{
    public class Food_ItemsController : Controller
    {
        private Zerohunger101Entities db = new Zerohunger101Entities();

        // GET: Food_Items
        public ActionResult Index()
        {
            var food_Items = db.Food_Items.Include(f => f.Collect_Requests);
            return View(food_Items.ToList());
        }

        // GET: Food_Items/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food_Items food_Items = db.Food_Items.Find(id);
            if (food_Items == null)
            {
                return HttpNotFound();
            }
            return View(food_Items);
        }

        // GET: Food_Items/Create
        public ActionResult Create()
        {
            ViewBag.Request_id = new SelectList(db.Collect_Requests, "Request_id", "Collection_status");
            return View();
        }

        // POST: Food_Items/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Food_item_id,Request_id,Item_name,Quantity,Expiry_date")] Food_Items food_Items)
        {
            if (ModelState.IsValid)
            {
                db.Food_Items.Add(food_Items);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Request_id = new SelectList(db.Collect_Requests, "Request_id", "Collection_status", food_Items.Request_id);
            return View(food_Items);
        }

        // GET: Food_Items/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food_Items food_Items = db.Food_Items.Find(id);
            if (food_Items == null)
            {
                return HttpNotFound();
            }
            ViewBag.Request_id = new SelectList(db.Collect_Requests, "Request_id", "Collection_status", food_Items.Request_id);
            return View(food_Items);
        }

        // POST: Food_Items/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Food_item_id,Request_id,Item_name,Quantity,Expiry_date")] Food_Items food_Items)
        {
            if (ModelState.IsValid)
            {
                db.Entry(food_Items).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Request_id = new SelectList(db.Collect_Requests, "Request_id", "Collection_status", food_Items.Request_id);
            return View(food_Items);
        }

        // GET: Food_Items/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food_Items food_Items = db.Food_Items.Find(id);
            if (food_Items == null)
            {
                return HttpNotFound();
            }
            return View(food_Items);
        }

        // POST: Food_Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Food_Items food_Items = db.Food_Items.Find(id);
            db.Food_Items.Remove(food_Items);
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
