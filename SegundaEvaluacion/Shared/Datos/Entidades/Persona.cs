using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundaEvaluacion.Shared.Datos.Entidades
{
    [Index(nameof(dni), Name = "UQ_Persona_dni", IsUnique = true)]
    public class Persona
    {
        public int Id { get; set; }

        [Display(Name = "DNI")]
        [Required(ErrorMessage = "El dni es requerido")]
        [MaxLength(8)]
        public int dni { get; set; }

        [Display(Name = "Nombres")]
        [Required(ErrorMessage = "El Nombre es requerido")]
        [MaxLength(50)]
        public string nombre { get; set; }

        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "El Apellido es requerido")]
        [MaxLength(50)]
        public string apellido { get; set; }

        [Display(Name = "Fecha de nacimiento")]
        [Required(ErrorMessage = "Fecha de nacimiento es requerida")]
        public DateTime fecha_nacimiento { get; set; }

        [Display(Name = "Nacionalidad")]
        [Required(ErrorMessage = "La Nacionalidad es requerida")]
        [MaxLength(120)]
        public Pais Nacionalidad { get; set; }
    }

}
