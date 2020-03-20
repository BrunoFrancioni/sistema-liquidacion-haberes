using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sistema_Liquidacion_de_Haberes.Models.DbFunctions
{
    public class ViewModelEmpleado
    {
        public int IdEmpleado { get; set; }

        /*
         * INFORMACIÓN PERSONAL
         */

        [Display(Name = "NOMBRE")]
        [Required]
        public string Nombre { get; set; }

        [Display(Name = "APELLIDO")]
        [Required]
        public string Apellido { get; set; }

        /*
         * INFORMACIÓN LABORAL
         */

        [Display(Name = "CUIL")]
        [Required]
        public string Cuil { get; set; }

        [Display(Name = "LUGAR DE TRABAJO")]
        [Required]
        public string LugarTrabajo { get; set; }

        [Display(Name = "LEGAJO")]
        public int Legajo { get; set; }

        [Display(Name = "ANTIGÜEDAD")]
        [Required]
        public System.DateTime Antiguedad { get; set; }

        [Display(Name = "FECHA DE INGRESO")]
        [Required]
        public System.DateTime FechaIngreso { get; set; }

        [Display(Name = "FECHA DE EGRESO")]
        public Nullable<System.DateTime> FechaEgreso { get; set; }

        [Display(Name = "SECTOR")]
        public string NombreSector { get; set; }

        [Display(Name = "CATEGORÍA")]
        [Required]
        public string NombreCategoria { get; set; }

        [Display(Name = "SALARIO BASE")]
        public decimal Salario { get; set; }

        [Display(Name = "ACTIVO")]
        public bool Activo { get; set; }

        /*
         * DATOS OBRA SOCIAL
         */

        [Display(Name = "OBRA SOCIAL")]
        [Required]
        public string ObraSocial { get; set; }

        [Display(Name = "PLAN")]
        public string Plan { get; set; }

        /*
         * DATOS CUENTA BANCARIA
         */

        [Display(Name = "BANCO")]
        public string NombreBanco { get; set; }

        [Display(Name = "CBU")]
        public long Cbu { get; set; }
    }
}