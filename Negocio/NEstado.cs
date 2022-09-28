using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;

namespace Negocio
{
    public class NEstado
    {
        InstitutoTichEntities1 _DBContex = new InstitutoTichEntities1();
        public List<Estados> Consultar()
        {
            List<Estados> listEstados = _DBContex.Estados.ToList();
            return listEstados;
        }

        public Estados Consultar(int id)
        {
            Estados est = _DBContex.Estados.Find(id);
            return est;
        }
    }
}
