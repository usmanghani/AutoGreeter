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
    public class GreetingController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        //
        // GET: /Greeting/

        public ViewResult Index()
        {
            return View(db.Greetings.ToList());
        }

        //
        // GET: /Greeting/Details/5

        public ViewResult Details(int id)
        {
            Greeting greeting = db.Greetings.Find(id);
            return View(greeting);
        }

        //
        // GET: /Greeting/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Greeting/Create

        [HttpPost]
        public ActionResult Create(Greeting greeting)
        {
            if (ModelState.IsValid)
            {
                db.Greetings.Add(greeting);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(greeting);
        }
        
        //
        // GET: /Greeting/Edit/5
 
        public ActionResult Edit(int id)
        {
            Greeting greeting = db.Greetings.Find(id);
            return View(greeting);
        }

        //
        // POST: /Greeting/Edit/5

        [HttpPost]
        public ActionResult Edit(Greeting greeting)
        {
            if (ModelState.IsValid)
            {
                db.Entry(greeting).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(greeting);
        }

        //
        // GET: /Greeting/Delete/5
 
        public ActionResult Delete(int id)
        {
            Greeting greeting = db.Greetings.Find(id);
            return View(greeting);
        }

        //
        // POST: /Greeting/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Greeting greeting = db.Greetings.Find(id);
            db.Greetings.Remove(greeting);
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