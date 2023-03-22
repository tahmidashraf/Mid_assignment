﻿using System;
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
    public class Collect_RequestsController : Controller
    {
        private Zerohunger101Entities db = new Zerohunger101Entities();

        // GET: Collect_Requests
        public ActionResult Index()
        {
            var collect_Requests = db.Collect_Requests.Include(c => c.Restaurant);
            return View(collect_Requests.ToList());
        }

        // GET: Collect_Requests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Collect_Requests collect_Requests = db.Collect_Requests.Find(id);
            if (collect_Requests == null)
            {
                return HttpNotFound();
            }
            return View(collect_Requests);
        }

        // GET: Collect_Requests/Create
        public ActionResult Create()
        {
            ViewBag.Restaurant_id = new SelectList(db.Restaurants, "Restaurant_id", "Name");
            return View();
        }

        // POST: Collect_Requests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Request_id,Restaurant_id,Maximum_preservation_time,Collection_date,Collection_status")] Collect_Requests collect_Requests)
        {
            if (ModelState.IsValid)
            {
                db.Collect_Requests.Add(collect_Requests);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Restaurant_id = new SelectList(db.Restaurants, "Restaurant_id", "Name", collect_Requests.Restaurant_id);
            return View(collect_Requests);
        }

        // GET: Collect_Requests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Collect_Requests collect_Requests = db.Collect_Requests.Find(id);
            if (collect_Requests == null)
            {
                return HttpNotFound();
            }
            ViewBag.Restaurant_id = new SelectList(db.Restaurants, "Restaurant_id", "Name", collect_Requests.Restaurant_id);
            return View(collect_Requests);
        }

        // POST: Collect_Requests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Request_id,Restaurant_id,Maximum_preservation_time,Collection_date,Collection_status")] Collect_Requests collect_Requests)
        {
            if (ModelState.IsValid)
            {
                db.Entry(collect_Requests).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Restaurant_id = new SelectList(db.Restaurants, "Restaurant_id", "Name", collect_Requests.Restaurant_id);
            return View(collect_Requests);
        }

        // GET: Collect_Requests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Collect_Requests collect_Requests = db.Collect_Requests.Find(id);
            if (collect_Requests == null)
            {
                return HttpNotFound();
            }
            return View(collect_Requests);
        }

        // POST: Collect_Requests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Collect_Requests collect_Requests = db.Collect_Requests.Find(id);
            db.Collect_Requests.Remove(collect_Requests);
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
