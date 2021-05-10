using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoFinca;

namespace ProyectoFinca.Controllers
{
    public class FamiliaresController : Controller
    {
        private FincasCafeterasEntities db = new FincasCafeterasEntities();

        // GET: Familiares
        public ActionResult Index()
        {
            var familiares = db.Familiares.Include(f => f.Finca).Include(f => f.Parentesco);
            return View(familiares.ToList());
        }

        // GET: Familiares/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Familiares familiares = db.Familiares.Find(id);
            if (familiares == null)
            {
                return HttpNotFound();
            }
            return View(familiares);
        }

        // GET: Familiares/Create
        public ActionResult Create()
        {
            ViewBag.Id_finca = new SelectList(db.Finca, "Codigo", "Nombre");
            ViewBag.Id_parentesco = new SelectList(db.Parentesco, "id", "Descripcion");
            return View();
        }

        // POST: Familiares/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Nombre,Id_parentesco,Id_finca")] Familiares familiares)
        {
            if (ModelState.IsValid)
            {
                db.Familiares.Add(familiares);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_finca = new SelectList(db.Finca, "Codigo", "Nombre", familiares.Id_finca);
            ViewBag.Id_parentesco = new SelectList(db.Parentesco, "id", "Descripcion", familiares.Id_parentesco);
            return View(familiares);
        }

        // GET: Familiares/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Familiares familiares = db.Familiares.Find(id);
            if (familiares == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_finca = new SelectList(db.Finca, "Codigo", "Nombre", familiares.Id_finca);
            ViewBag.Id_parentesco = new SelectList(db.Parentesco, "id", "Descripcion", familiares.Id_parentesco);
            return View(familiares);
        }

        // POST: Familiares/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Nombre,Id_parentesco,Id_finca")] Familiares familiares)
        {
            if (ModelState.IsValid)
            {
                db.Entry(familiares).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_finca = new SelectList(db.Finca, "Codigo", "Nombre", familiares.Id_finca);
            ViewBag.Id_parentesco = new SelectList(db.Parentesco, "id", "Descripcion", familiares.Id_parentesco);
            return View(familiares);
        }

        // GET: Familiares/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Familiares familiares = db.Familiares.Find(id);
            if (familiares == null)
            {
                return HttpNotFound();
            }
            return View(familiares);
        }

        // POST: Familiares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Familiares familiares = db.Familiares.Find(id);
            db.Familiares.Remove(familiares);
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
