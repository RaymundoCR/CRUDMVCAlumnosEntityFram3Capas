using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio;
using Entidades;
using Negocio.WCFAlumnos;

namespace Presentacion.Controllers
{
    public class AlumnoController : Controller
    {
        NAlumno _oAlumno = new NAlumno();
        NEstado _oEstado = new NEstado();
        NEstatusAlumno _oEstatus = new NEstatusAlumno();
        // GET: Alumno
        public ActionResult Index()
        {
            List<Alumnos> lisAlumnos = _oAlumno.Consultar();
            return View(lisAlumnos);
        }

        // GET: Alumno/Details/5
        public ActionResult Details(int id)
        {
            return View(_oAlumno.Consultar(id));
        }

        // GET: Alumno/Create
        public ActionResult Create()
        {
            
            ViewBag.Estados = _oEstado.Consultar();
            ViewBag.Estatus = _oEstatus.Consultar();
            return View();
        }

        // POST: Alumno/Create
        [HttpPost]
        public ActionResult Create(Alumnos alumno)
        {
            try
            {
                _oAlumno.Agregar(alumno);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Alumno/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Estados = _oEstado.Consultar();
            ViewBag.Estatus = _oEstatus.Consultar();
            return View(_oAlumno.Consultar(id));
        }

        // POST: Alumno/Edit/5
        [HttpPost]
        public ActionResult Edit(Alumnos alumno)
        {
            try
            {
                _oAlumno.Actualizar(alumno);
                Redirect("Index");

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Alumno/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_oAlumno.Consultar(id));
        }

        // POST: Alumno/Delete/5
        [HttpPost]
        public ActionResult Delete(Alumnos alumnos)
        {
            try
            {
                _oAlumno.Eliminar(alumnos.id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult _AportacionesIMSS(int id)
        {
            AportacionesIMSS imss = _oAlumno.CalcularIMSS(id);
            return PartialView(imss);
        }

        public ActionResult _TablaISR(int id)
        {
            ItemTablaISR isr = _oAlumno.CalcularISR(id);
            return PartialView(isr);
        }
    }
}
