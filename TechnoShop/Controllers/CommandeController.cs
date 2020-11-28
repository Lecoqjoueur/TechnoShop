using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TechnoShop.DAL;
using TechnoShop.Models;

namespace TechnoShop.Controllers
{
    public class CommandeController : Controller
    {
        private MagasinContext db = new MagasinContext();

        // GET: Commande
        public ActionResult Index()
        {
            var commandes = db.Commandes.Include(c => c.Clients).Include(c => c.Produits);
            return View(commandes.ToList());
        }

        // GET: Commande/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commande commande = db.Commandes.Find(id);
            if (commande == null)
            {
                return HttpNotFound();
            }
            return View(commande);
        }

        // GET: Commande/Create
        public ActionResult Create()
        {
            ViewBag.IDClient = new SelectList(db.Clients, "IDClient", "pseudo");
            ViewBag.IDProduit = new SelectList(db.Produits, "IDProduit", "nom");
            return View();
        }

        // POST: Commande/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDCommande,IDClient,IDProduit,quantite,Grade")] Commande commande)
        {
            if (ModelState.IsValid)
            {
                db.Commandes.Add(commande);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDClient = new SelectList(db.Clients, "IDClient", "pseudo", commande.IDClient);
            ViewBag.IDProduit = new SelectList(db.Produits, "IDProduit", "nom", commande.IDProduit);
            return View(commande);
        }

        // GET: Commande/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commande commande = db.Commandes.Find(id);
            if (commande == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDClient = new SelectList(db.Clients, "IDClient", "pseudo", commande.IDClient);
            ViewBag.IDProduit = new SelectList(db.Produits, "IDProduit", "nom", commande.IDProduit);
            return View(commande);
        }

        // POST: Commande/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDCommande,IDClient,IDProduit,quantite,Grade")] Commande commande)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commande).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDClient = new SelectList(db.Clients, "IDClient", "pseudo", commande.IDClient);
            ViewBag.IDProduit = new SelectList(db.Produits, "IDProduit", "nom", commande.IDProduit);
            return View(commande);
        }

        // GET: Commande/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commande commande = db.Commandes.Find(id);
            if (commande == null)
            {
                return HttpNotFound();
            }
            return View(commande);
        }

        // POST: Commande/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Commande commande = db.Commandes.Find(id);
            db.Commandes.Remove(commande);
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
