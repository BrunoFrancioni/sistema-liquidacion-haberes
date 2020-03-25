using Sistema_Liquidacion_de_Haberes.Models.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_Liquidacion_de_Haberes.Models.DbFunctions
{
    public class ViewModelCreateEmployee
    {
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

        [Display(Name = "ANTIGÜEDAD")]
        [Required]
        public System.DateTime Antiguedad { get; set; }

        [Display(Name = "FECHA DE INGRESO")]
        [Required]
        public System.DateTime FechaIngreso { get; set; }

        [Required(ErrorMessage = "El campo OBRA SOCIAL es obligatorio.")]
        public int IdObraSocial { get; set; }

        [Required(ErrorMessage = "El campo BANCO es obligatorio.")]
        public int IdBanco { get; set; }

        [Required(ErrorMessage = "El campo CATEGORÍA es obligatorio.")]
        public int IdCategoria { get; set; }
    }
}