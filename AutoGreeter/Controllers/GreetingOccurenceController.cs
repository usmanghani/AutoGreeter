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
    public class GreetingOccurenceController : Controller
    {
        private IGreeterContext db;

        public GreetingOccurenceController(IGreeterContext context)
        {
            this.db = context;
        }

        //
        // GET: /GreetingOccurence/

        public ViewResult Index()
        {
            var greetingoccurences = db.GreetingOccurences.Include(g => g.User);
            return View(greetingoccurences.ToList());
        }

        //
        // GET: /GreetingOccurence/Details/5

        public ViewResult Details(int id)
        {
            GreetingOccurence greetingoccurence = db.GreetingOccurences.Find(id);
            return View(greetingoccurence);
        }

        //
        // GET: /GreetingOccurence/Create

        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "Username");
            return View();
        } 

        //
        // POST: /GreetingOccurence/Create

        [HttpPost]
        public ActionResult Create(GreetingOccurence greetingoccurence)
        {
            if (ModelState.IsValid)
            {
                db.GreetingOccurences.Add(greetingoccurence);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "Username", greetingoccurence.UserId);
            return View(greetingoccurence);
        }
        
        //
        // GET: /GreetingOccurence/Edit/5
 
        public ActionResult Edit(int id)
        {
            GreetingOccurence greetingoccurence = db.GreetingOccurences.Find(id);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Username", greetingoccurence.UserId);
            return View(greetingoccurence);
        }

        //
        // POST: /GreetingOccurence/Edit/5

        [HttpPost]
        public ActionResult Edit(GreetingOccurence greetingoccurence)
        {
            if (ModelState.IsValid)
            {
                db.Entry(greetingoccurence).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Username", greetingoccurence.UserId);
            return View(greetingoccurence);
        }

        //
        // GET: /GreetingOccurence/Delete/5
 
        public ActionResult Delete(int id)
        {
            GreetingOccurence greetingoccurence = db.GreetingOccurences.Find(id);
            return View(greetingoccurence);
        }

        //
        // POST: /GreetingOccurence/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            GreetingOccurence greetingoccurence = db.GreetingOccurences.Find(id);
            db.GreetingOccurences.Remove(greetingoccurence);
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