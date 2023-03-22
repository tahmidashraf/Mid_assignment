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
    public class Collection_LogsController : Controller
    {
        private Zerohunger101Entities db = new Zerohunger101Entities();

        // GET: Collection_Logs
        public ActionResult Index()
        {
            var collection_Logs = db.Collection_Logs.Include(c => c.Collect_Requests).Include(c => c.Employee);
            return View(collection_Logs.ToList());
        }

        // GET: Collection_Logs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Collection_Logs collection_Logs = db.Collection_Logs.Find(id);
            if (collection_Logs == null)
            {
                return HttpNotFound();
            }
            return View(collection_Logs);
        }

        // GET: Collection_Logs/Create
        public ActionResult Create()
        {
            ViewBag.Request_id = new SelectList(db.Collect_Requests, "Request_id", "Collection_status");
            ViewBag.Employee_id = new SelectList(db.Employees, "Employee_id", "Name");
            return View();
        }

        // POST: Collection_Logs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Log_id,Request_id,Employee_id,Collection_date,Distribution_date,Distribution_status")] Collection_Logs collection_Logs)
        {
            if (ModelState.IsValid)
            {
                db.Collection_Logs.Add(collection_Logs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Request_id = new SelectList(db.Collect_Requests, "Request_id", "Collection_status", collection_Logs.Request_id);
            ViewBag.Employee_id = new SelectList(db.Employees, "Employee_id", "Name", collection_Logs.Employee_id);
            return View(collection_Logs);
        }

        // GET: Collection_Logs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Collection_Logs collection_Logs = db.Collection_Logs.Find(id);
            if (collection_Logs == null)
            {
                return HttpNotFound();
            }
            ViewBag.Request_id = new SelectList(db.Collect_Requests, "Request_id", "Collection_status", collection_Logs.Request_id);
            ViewBag.Employee_id = new SelectList(db.Employees, "Employee_id", "Name", collection_Logs.Employee_id);
            return View(collection_Logs);
        }

        // POST: Collection_Logs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Log_id,Request_id,Employee_id,Collection_date,Distribution_date,Distribution_status")] Collection_Logs collection_Logs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(collection_Logs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Request_id = new SelectList(db.Collect_Requests, "Request_id", "Collection_status", collection_Logs.Request_id);
            ViewBag.Employee_id = new SelectList(db.Employees, "Employee_id", "Name", collection_Logs.Employee_id);
            return View(collection_Logs);
        }

        // GET: Collection_Logs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Collection_Logs collection_Logs = db.Collection_Logs.Find(id);
            if (collection_Logs == null)
            {
                return HttpNotFound();
            }
            return View(collection_Logs);
        }

        // POST: Collection_Logs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Collection_Logs collection_Logs = db.Collection_Logs.Find(id);
            db.Collection_Logs.Remove(collection_Logs);
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
