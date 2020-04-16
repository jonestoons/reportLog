﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using reportLog.Models;
using reportLog.Models.DataModels;
using reportLog.Models.Bloc;

namespace reportLog.Controllers
{
    public class RidersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Riders
        public ActionResult Index()
        {
            return View(db.Riders.ToList());
        }

        // GET: Riders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rider rider = db.Riders.Find(id);
            if (rider == null)
            {
                return HttpNotFound();
            }
            return View(rider);
        }

        // GET: Riders/Create
        public ActionResult Create()
        {
            ViewBag.UserID = EntityGenerator.generateUserID();
            return View();
        }

        // POST: Riders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserID,CompanyID,FirstName,LastName,OtherName,Phone,Password,Address,DoB,NextOfKin,NextOfKinNumber,SbDate,SbExpiry,TimeStamp")] Rider rider)
        {
                rider.TimeStamp = DateTime.Now;

            if (ModelState.IsValid)
            {
                rider.Password = PasswordHandler.CreatePasswordHash(rider.Password);
                rider.SbDate = DateTime.Now;
                rider.SbExpiry = DateTime.Now;
                db.Riders.Add(rider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rider);
        }

        // GET: Riders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rider rider = db.Riders.Find(id);
            if (rider == null)
            {
                return HttpNotFound();
            }
            return View(rider);
        }

        // POST: Riders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserID,CompanyID,FirstName,LastName,OtherName,Phone,Password,Address,DoB,NextOfKin,NextOfKinNumber,SbDate,SbExpiry,TimeStamp")] Rider rider)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rider).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rider);
        }

        // GET: Riders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rider rider = db.Riders.Find(id);
            if (rider == null)
            {
                return HttpNotFound();
            }
            return View(rider);
        }

        // POST: Riders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rider rider = db.Riders.Find(id);
            db.Riders.Remove(rider);
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
