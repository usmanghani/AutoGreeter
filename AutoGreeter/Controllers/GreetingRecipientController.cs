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
    public class GreetingRecipientController : Controller
    {
        private IGreeterContext db;

        public GreetingRecipientController(IGreeterContext context)
        {
            this.db = context;
        }

        //
        // GET: /GreetingRecipient/

        public ViewResult Index()
        {
            var GreetingRecipients = db.GreetingRecipients.Include(g => g.User);
            return View(GreetingRecipients.ToList());
        }

        //
        // GET: /GreetingRecipient/Details/5

        public ViewResult Details(int id)
        {
            GreetingRecipient greetingtarget = db.GreetingRecipients.Find(id);
            return View(greetingtarget);
        }

        //
        // GET: /GreetingRecipient/Create

        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "Username");
            return View();
        } 

        //
        // POST: /GreetingRecipient/Create

        [HttpPost]
        public ActionResult Create(GreetingRecipient greetingtarget)
        {
            if (ModelState.IsValid)
            {
                db.GreetingRecipients.Add(greetingtarget);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "Username", greetingtarget.UserId);
            return View(greetingtarget);
        }
        
        //
        // GET: /GreetingRecipient/Edit/5
 
        public ActionResult Edit(int id)
        {
            GreetingRecipient greetingtarget = db.GreetingRecipients.Find(id);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Username", greetingtarget.UserId);
            return View(greetingtarget);
        }

        //
        // POST: /GreetingRecipient/Edit/5

        [HttpPost]
        public ActionResult Edit(GreetingRecipient greetingtarget)
        {
            if (ModelState.IsValid)
            {
                db.Entry(greetingtarget).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Username", greetingtarget.UserId);
            return View(greetingtarget);
        }

        //
        // GET: /GreetingRecipient/Delete/5
 
        public ActionResult Delete(int id)
        {
            GreetingRecipient greetingtarget = db.GreetingRecipients.Find(id);
            return View(greetingtarget);
        }

        //
        // POST: /GreetingRecipient/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            GreetingRecipient greetingtarget = db.GreetingRecipients.Find(id);
            db.GreetingRecipients.Remove(greetingtarget);
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