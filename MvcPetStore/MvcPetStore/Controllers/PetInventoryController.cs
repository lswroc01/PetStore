using MvcPetStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPetStore.Controllers
{
    public class PetInventoryController : Controller
    {
        private PetStoreDBContext db = new PetStoreDBContext();
        //
        // GET: /PetInventory/
        public ActionResult Index()
        {
            return View(db.Pets.ToList());
        }

        public ActionResult Details(int ID = 1)
        {
            ViewBag.ID = ID;

            return View(db.Pets.ToList());
        }
    }
}