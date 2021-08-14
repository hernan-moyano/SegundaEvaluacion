using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundaEvaluacion.Shared.Datos.Entidades
{
    [Index(nameof(CodPais), Name = "UQ_Pais_CodPais", IsUnique = true)]

    public class Pais
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El codigo es obligatorio.")]
        [MaxLength(3, ErrorMessage = "El maximo de caracteres es {1}.")]
        public string CodPais { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MaxLength(120, ErrorMessage = "El maximo de caracteres es {1}.")]
        public string NombrePais { get; set; } 
       
    }

}
