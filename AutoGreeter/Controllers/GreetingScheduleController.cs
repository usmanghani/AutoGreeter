using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoGreeter.Models;

namespace AutoGreeter.Controllers
{ 
    public class GreetingScheduleController : Controller
    {
        private IGreeterContext db;

        public GreetingScheduleController(IGreeterContext context)
        {
            this.db = context;
        }

        //
        // GET: /GreetingSchedule/

        public ViewResult Index()
        {
            var greetingschedules = db.GreetingSchedules.Include(g => g.User);
            return View(greetingschedules.ToList());
        }

        //
        // GET: /GreetingSchedule/Details/5

        public ViewResult Details(int id)
        {
            GreetingSchedule greetingschedule = db.GreetingSchedules.Find(id);
            return View(greetingschedule);
        }

        //
        // GET: /GreetingSchedule/Create

        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "Username");
            return View();
        } 

        //
        // POST: /GreetingSchedule/Create

        [HttpPost]
        public ActionResult Create(GreetingSchedule greetingschedule)
        {
            if (ModelState.IsValid)
            {
                db.GreetingSchedules.Add(greetingschedule);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "Username", greetingschedule.UserId);
            return View(greetingschedule);
        }
        
        //
        // GET: /GreetingSchedule/Edit/5
 
        public ActionResult Edit(int id)
        {
            GreetingSchedule greetingschedule = db.GreetingSchedules.Find(id);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Username", greetingschedule.UserId);
            return View(greetingschedule);
        }

        //
        // POST: /GreetingSchedule/Edit/5

        [HttpPost]
        public ActionResult Edit(GreetingSchedule greetingschedule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(greetingschedule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Username", greetingschedule.UserId);
            return View(greetingschedule);
        }

        //
        // GET: /GreetingSchedule/Delete/5
 
        public ActionResult Delete(int id)
        {
            GreetingSchedule greetingschedule = db.GreetingSchedules.Find(id);
            return View(greetingschedule);
        }

        //
        // POST: /GreetingSchedule/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            GreetingSchedule greetingschedule = db.GreetingSchedules.Find(id);
            db.GreetingSchedules.Remove(greetingschedule);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}