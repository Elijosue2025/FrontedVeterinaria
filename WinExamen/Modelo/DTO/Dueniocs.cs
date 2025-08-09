using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinExamen.Modelo.DTO
{
    public class Dueniocs
    {
        public int pk_duenio { get; set; }
        public string d_nombre { get; set; }
        public string d_apellido { get; set; }
        public string d_telefono { get; set; }
        public string d_email { get; set; }
        public string d_direccion { get; set; }
        public DateTime? d_fechaRegistro { get; set; }
        public bool d_estado { get; set; } = true;

        public string NombreCompleto => $"{d_nombre} {d_apellido}";
    }
}
