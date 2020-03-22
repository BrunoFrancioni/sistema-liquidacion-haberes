using Sistema_Liquidacion_de_Haberes.Models.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_Liquidacion_de_Haberes.Models.DbFunctions
{
    public class ViewModelEditEmployee
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

        [Display(Name = "ANTIGÜEDAD")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime Antiguedad { get; set; }

        [Display(Name = "FECHA DE INGRESO")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime FechaIngreso { get; set; }

        [Display(Name = "OBRA SOCIAL")]
        [Required]
        public IEnumerable<SelectListItem> ObrasSociales { get; set; }

        public int IdSectorActivo { get; set; }

        [Display(Name = "SECTOR")]
        public IEnumerable<sectores> Sectores { get; set; }

        [Display(Name = "CATEGORÍA")]
        [Required]
        public IEnumerable<SelectListItem> Categorias { get; set; }
    }
}