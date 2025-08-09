using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinExamen.Modelo.DTO
{
    public class Mascotas
    {
        public int pk_mascota { get; set; }
        public string ma_nombre { get; set; }
        public string ma_especie { get; set; }
        public string ma_raza { get; set; }
        public DateTime ma_fechaNacimiento { get; set; }
        public decimal? ma_peso { get; set; }
        public string ma_color { get; set; }
        public string ma_genero { get; set; }
        public int fk_duenio { get; set; }
        public DateTime? ma_fechaRegistro { get; set; }
        public bool ma_estado { get; set; } = true;

        public int Edad => DateTime.Now.Year - ma_fechaNacimiento.Year;
        public string NombreConEspecie => $"{ma_nombre} ({ma_especie})";
    }
}
