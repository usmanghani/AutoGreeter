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
    public class UserSessionController : Controller
    {
        private IGreeterContext db;

        public UserSessionController(IGreeterContext context)
        {
            this.db = context;
        }

        //
        // GET: /UserSession/

        public ViewResult Index()
        {
            var sessions = db.Sessions.Include(u => u.User);
            return View(sessions.ToList());
        }

        //
        // GET: /UserSession/Details/5

        public ViewResult Details(int id)
        {
            UserSession usersession = db.Sessions.Find(id);
            return View(usersession);
        }

        //
        // GET: /UserSession/Create

        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "Username");
            return View();
        } 

        //
        // POST: /UserSession/Create

        [HttpPost]
        public ActionResult Create(UserSession usersession)
        {
            if (ModelState.IsValid)
            {
                db.Sessions.Add(usersession);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "Username", usersession.UserId);
            return View(usersession);
        }
        
        //
        // GET: /UserSession/Edit/5
 
        public ActionResult Edit(int id)
        {
            UserSession usersession = db.Sessions.Find(id);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Username", usersession.UserId);
            return View(usersession);
        }

        //
        // POST: /UserSession/Edit/5

        [HttpPost]
        public ActionResult Edit(UserSession usersession)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usersession).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Username", usersession.UserId);
            return View(usersession);
        }

        //
        // GET: /UserSession/Delete/5
 
        public ActionResult Delete(int id)
        {
            UserSession usersession = db.Sessions.Find(id);
            return View(usersession);
        }

        //
        // POST: /UserSession/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            UserSession usersession = db.Sessions.Find(id);
            db.Sessions.Remove(usersession);
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