using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcPetStore.Models;

namespace MvcPetStore.Controllers
{
    public class PetManagerController : Controller
    {
        private PetStoreDBContext db = new PetStoreDBContext();

        // GET: /PetManager/
        public ActionResult Index(string PetType, string searchString)
        {
            var PetTypeLst = new List<string>();

            var PetTypeQry = from d in db.Pets
                             orderby d.PetType
                             select d.PetType;

            PetTypeLst.AddRange(PetTypeQry.Distinct());
            ViewBag.PetType = new SelectList(PetTypeLst);

            var pets = from p in db.Pets
                       select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                pets = pets.Where(d => d.Description.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(PetType))
            {
                pets = pets.Where(x => x.PetType == PetType);
            }

            return View(pets);
        }

        // GET: /PetManager/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet pets = db.Pets.Find(id);
            if (pets == null)
            {
                return HttpNotFound();
            }
            return View(pets);
        }

        // GET: /PetManager/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /PetManager/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PetType,Breed,Gender,Description,Location,Price")] Pet pets)
        {
            if (ModelState.IsValid)
            {
                db.Pets.Add(pets);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pets);
        }

        // GET: /PetManager/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet pets = db.Pets.Find(id);
            if (pets == null)
            {
                return HttpNotFound();
            }
            return View(pets);
        }

        // POST: /PetManager/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PetType,Breed,Gender,Description,Location,Price")] Pet pets)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pets).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pets);
        }

        // GET: /PetManager/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet pets = db.Pets.Find(id);
            if (pets == null)
            {
                return HttpNotFound();
            }
            return View(pets);
        }

        // POST: /PetManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pet pets = db.Pets.Find(id);
            db.Pets.Remove(pets);
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
