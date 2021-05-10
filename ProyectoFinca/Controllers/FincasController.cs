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
    public class FincasController : Controller
    {
        private FincasCafeterasEntities db = new FincasCafeterasEntities();

        // GET: Fincas
        public ActionResult Index()
        {
            var finca = db.Finca.Include(f => f.Administrador);
            return View(finca.ToList());
        }

        // GET: Fincas/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Finca finca = db.Finca.Find(id);
            if (finca == null)
            {
                return HttpNotFound();
            }
            return View(finca);
        }

        // GET: Fincas/Create
        public ActionResult Create()
        {
            ViewBag.IdAdmin = new SelectList(db.Administrador, "Id", "Nombre");
            return View();
        }

        // POST: Fincas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Codigo,Nombre,Vereda,Municipio,Departamento,IdAdmin")] Finca finca)
        {
            if (ModelState.IsValid)
            {
                db.Finca.Add(finca);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdAdmin = new SelectList(db.Administrador, "Id", "Nombre", finca.IdAdmin);
            return View(finca);
        }

        // GET: Fincas/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Finca finca = db.Finca.Find(id);
            if (finca == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdAdmin = new SelectList(db.Administrador, "Id", "Nombre", finca.IdAdmin);
            return View(finca);
        }

        // POST: Fincas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codigo,Nombre,Vereda,Municipio,Departamento,IdAdmin")] Finca finca)
        {
            if (ModelState.IsValid)
            {
                db.Entry(finca).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdAdmin = new SelectList(db.Administrador, "Id", "Nombre", finca.IdAdmin);
            return View(finca);
        }

        // GET: Fincas/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Finca finca = db.Finca.Find(id);
            if (finca == null)
            {
                return HttpNotFound();
            }
            return View(finca);
        }

        // POST: Fincas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Finca finca = db.Finca.Find(id);
            db.Finca.Remove(finca);
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
