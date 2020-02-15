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
    public class RegistriesController : Controller
    {
        private DbConnectionString db = new DbConnectionString();

        // GET: Registries
        public ActionResult Index()
        {
            return View(db.Registries.ToList());
        }

        // GET: Registries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registry registry = db.Registries.Find(id);
            if (registry == null)
            {
                return HttpNotFound();
            }
            return View(registry);
        }

        // GET: Registries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Registries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdRegistry,FirstLastName,Email,PhoneNumber,FullAddress,ClientFlag,InternalFlag,SupplierFlag,RegistryCode,Username,PassWordField")] Registry registry)
        {
            if (ModelState.IsValid)
            {
                db.Registries.Add(registry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(registry);
        }

        // GET: Registries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registry registry = db.Registries.Find(id);
            if (registry == null)
            {
                return HttpNotFound();
            }
            return View(registry);
        }

        // POST: Registries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdRegistry,FirstLastName,Email,PhoneNumber,FullAddress,ClientFlag,InternalFlag,SupplierFlag,RegistryCode,Username,PassWordField")] Registry registry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(registry);
        }

        // GET: Registries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registry registry = db.Registries.Find(id);
            if (registry == null)
            {
                return HttpNotFound();
            }
            return View(registry);
        }

        // POST: Registries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Registry registry = db.Registries.Find(id);
            db.Registries.Remove(registry);
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
