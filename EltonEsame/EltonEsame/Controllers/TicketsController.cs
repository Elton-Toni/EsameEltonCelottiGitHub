using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EltonEsame.Models;

namespace EltonEsame.Controllers
{
    public class TicketsController : Controller
    {
        private DbConnectionString db = new DbConnectionString();

        // GET: Tickets
        public ActionResult Index()
        {
            var tickets = db.Tickets.Include(t => t.Registry).Include(t => t.Registry1);
            return View(tickets.ToList());
        }

        // GET: Tickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // GET: Tickets/Create
        public ActionResult Create()
        {
            ViewBag.InternaPersonId = new SelectList(db.Registries, "IdRegistry", "FirstLastName");
            ViewBag.RegistryId = new SelectList(db.Registries, "IdRegistry", "FirstLastName");
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTicket,RegistryId,InternaPersonId,RequestDate,ClosingDate,RequestState,RequestTitle,RequestDescription,ResponseDescription")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Tickets.Add(ticket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InternaPersonId = new SelectList(db.Registries, "IdRegistry", "FirstLastName", ticket.InternaPersonId);
            ViewBag.RegistryId = new SelectList(db.Registries, "IdRegistry", "FirstLastName", ticket.RegistryId);
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            ViewBag.InternaPersonId = new SelectList(db.Registries, "IdRegistry", "FirstLastName", ticket.InternaPersonId);
            ViewBag.RegistryId = new SelectList(db.Registries, "IdRegistry", "FirstLastName", ticket.RegistryId);
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTicket,RegistryId,InternaPersonId,RequestDate,ClosingDate,RequestState,RequestTitle,RequestDescription,ResponseDescription")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InternaPersonId = new SelectList(db.Registries, "IdRegistry", "FirstLastName", ticket.InternaPersonId);
            ViewBag.RegistryId = new SelectList(db.Registries, "IdRegistry", "FirstLastName", ticket.RegistryId);
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ticket ticket = db.Tickets.Find(id);
            db.Tickets.Remove(ticket);
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
