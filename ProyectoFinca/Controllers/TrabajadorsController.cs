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
    public class TrabajadorsController : Controller
    {
        private FincasCafeterasEntities db = new FincasCafeterasEntities();

        // GET: Trabajadors
        public ActionResult Index()
        {
            var trabajador = db.Trabajador.Include(t => t.Finca).Include(t => t.Rol);
            return View(trabajador.ToList());
        }

        // GET: Trabajadors/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trabajador trabajador = db.Trabajador.Find(id);
            if (trabajador == null)
            {
                return HttpNotFound();
            }
            return View(trabajador);
        }

        // GET: Trabajadors/Create
        public ActionResult Create()
        {
            ViewBag.id_finca = new SelectList(db.Finca, "Codigo", "Nombre");
            ViewBag.id_rol = new SelectList(db.Rol, "id", "Descripcion");
            return View();
        }

        // POST: Trabajadors/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Nombre,id_rol,id_finca")] Trabajador trabajador)
        {
            if (ModelState.IsValid)
            {
                db.Trabajador.Add(trabajador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_finca = new SelectList(db.Finca, "Codigo", "Nombre", trabajador.id_finca);
            ViewBag.id_rol = new SelectList(db.Rol, "id", "Descripcion", trabajador.id_rol);
            return View(trabajador);
        }

        // GET: Trabajadors/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trabajador trabajador = db.Trabajador.Find(id);
            if (trabajador == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_finca = new SelectList(db.Finca, "Codigo", "Nombre", trabajador.id_finca);
            ViewBag.id_rol = new SelectList(db.Rol, "id", "Descripcion", trabajador.id_rol);
            return View(trabajador);
        }

        // POST: Trabajadors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Nombre,id_rol,id_finca")] Trabajador trabajador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trabajador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_finca = new SelectList(db.Finca, "Codigo", "Nombre", trabajador.id_finca);
            ViewBag.id_rol = new SelectList(db.Rol, "id", "Descripcion", trabajador.id_rol);
            return View(trabajador);
        }

        // GET: Trabajadors/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trabajador trabajador = db.Trabajador.Find(id);
            if (trabajador == null)
            {
                return HttpNotFound();
            }
            return View(trabajador);
        }

        // POST: Trabajadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Trabajador trabajador = db.Trabajador.Find(id);
            db.Trabajador.Remove(trabajador);
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
