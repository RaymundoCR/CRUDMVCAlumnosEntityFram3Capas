using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;
using System.Data.Entity;
using Negocio;
using Newtonsoft.Json;
using Negocio.WCFAlumnos;

namespace Negocio
{
    public class NAlumno
    {
        WCFAlumnosClient _objWCF = new WCFAlumnosClient();
        private Alumnos _oAlumno;
        InstitutoTichEntities1 _DBContex = new InstitutoTichEntities1();

        public List<Alumnos> Consultar()
        {
            List<Alumnos> listAlumnos = _DBContex.Alumnos.ToList();
            return listAlumnos;
        }
        public Alumnos Consultar(int id)
        {
            Alumnos alumnos = _DBContex.Alumnos.Find(id);
            return alumnos;
        }
        public void Agregar(Alumnos alumno)
        {
            _DBContex.Alumnos.Add(alumno);
            _DBContex.SaveChanges();

            _oAlumno = _DBContex.Alumnos.Find(alumno.id);
        }
        public void Actualizar(Alumnos alumno)
        {
            _DBContex.Entry(alumno).State = EntityState.Modified;
            _DBContex.SaveChanges();
        }
        public void Eliminar(int id)
        {
            _oAlumno = _DBContex.Alumnos.Find(id);
            _DBContex.Alumnos.Remove(_oAlumno);
            _DBContex.SaveChanges();
        }

        public AportacionesIMSS CalcularIMSS(int id)
        {
            AportacionesIMSS wcfResult = _objWCF.CalcularIMSS(id);
            //string json = JsonConvert.SerializeObject(wcfResult);
            //return JsonConvert.DeserializeObject<AportacionesIMSS>(json);
            return wcfResult;
        }

        public ItemTablaISR CalcularISR(int id)
        {
            ItemTablaISR wcfResult = _objWCF.CalcularISR(id);
            //string json = JsonConvert.SerializeObject(wcfResult);
            //return JsonConvert.DeserializeObject<ItemTablaISR>(json);
            return wcfResult;
        }
    }
}
