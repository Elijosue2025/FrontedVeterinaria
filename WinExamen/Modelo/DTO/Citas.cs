using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinExamen.Modelo.DTO
{
    public class Citas
    {
        public int pk_cita { get; set; }

        [Required(ErrorMessage = "La mascota es requerida")]
        public int fk_mascota { get; set; }

        [Required(ErrorMessage = "La fecha de cita es requerida")]
        public DateTime ci_fechaCita { get; set; }

        [Required(ErrorMessage = "El motivo es requerido")]
        [StringLength(200, ErrorMessage = "El motivo no puede exceder 200 caracteres")]
        public string ci_motivo { get; set; }

        [StringLength(500, ErrorMessage = "Las observaciones no pueden exceder 500 caracteres")]
        public string ci_observaciones { get; set; }

        public string ci_estadoCita { get; set; } = "Programada";
        public DateTime? ci_fechaCreacion { get; set; }
        public bool? ci_estado { get; set; } = true;
    }
}
