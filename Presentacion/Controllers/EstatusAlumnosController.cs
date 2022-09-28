using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;
using Negocio;

namespace Presentacion.Controllers
{
    public class EstatusAlumnosController : Controller
    {
        NEstatusAlumno _objNestatus = new NEstatusAlumno();
        List<EstatusAlumnos> _listaEstatus = new List<EstatusAlumnos>();
        EstatusAlumnos _objEstatus = new EstatusAlumnos();
        // GET: EstatusAlumnos
        public ActionResult Index()
        {
            _listaEstatus = _objNestatus.Consultar();
            return View(_listaEstatus);
        }

        // GET: EstatusAlumnos/Details/5
        public ActionResult Details(int id)
        {
            _objEstatus = _objNestatus.Consultar(id);
            return View(_objEstatus);
        }

        // GET: EstatusAlumnos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstatusAlumnos/Create
        [HttpPost]
        public ActionResult Create(EstatusAlumnos estatus)
        {
            try
            {
                // TODO: Add insert logic here
                _objNestatus.Agregar(estatus);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EstatusAlumnos/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_objNestatus.Consultar(id));
        }

        // POST: EstatusAlumnos/Edit/5
        [HttpPost]
        public ActionResult Edit(EstatusAlumnos estatus)
        {
            try
            {
                // TODO: Add update logic here
                _objNestatus.Actualizar(estatus);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EstatusAlumnos/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_objNestatus.Consultar(id));
        }

        // POST: EstatusAlumnos/Delete/5
        [HttpPost]
        public ActionResult Delete(EstatusAlumnos estatus)
        {
            try
            {
                // TODO: Add delete logic here
                _objNestatus.Eliminar(estatus.id);
                Redirect("Index");
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
