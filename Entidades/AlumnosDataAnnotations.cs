using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Entidades
{
    [MetadataType(typeof(AlumnosDataAnnotations))]
    public partial class Alumnos
    {
    }
    internal class AlumnosDataAnnotations
    {
        
        [Required(ErrorMessage = "El {0} es obligatorio")]
        [RegularExpression("^[A-z À-ÿ]+$", ErrorMessage = "{0}: Entrada de caracteres no valida")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "El {0} es obligatorio")]
        [RegularExpression("^[A-z À-ÿ]+$", ErrorMessage = "{0}: Entrada de caracteres no valida")]
        public string primerApellido { get; set; }

        [RegularExpression("^[A-z À-ÿ]+$", ErrorMessage = "{0}: Entrada de caracteres no valida")]
        public string segundoApellido { get; set; }

        [Required(ErrorMessage = "La {0} es obligatorio")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public string fechaNacimiento { get; set; }

        [Required(ErrorMessage = "La {0} no tiene el formato correcto")]
        [RegularExpression("^[A-Z]{4}[0-9]{2}[0-9]{2}[0-9]{2}[HM]{1}(AS|BS|CL|CS|DF|GT|HG|MC|MS|NL|PL|QR|SL|TC|TL|YN|NE|BC|CC|CM|CH|DG|GR|JC|MN|NT|OC|QT|SP|SR|TS|VZ|ZS){1}[^AEIOU\\d\\W]{3}[0-9]{2}$", ErrorMessage = "{0}: Entrada de caracteres no valida")]
        public string curp { get; set; }

        [Required(ErrorMessage = "El {0} es obligatorio")]
        public string correo { get; set; }

        [Range(10000, 40000, ErrorMessage = "El valor debe estar entre el {1} y el {2}")]
        public string sueldo { get; set; }
    }
}
