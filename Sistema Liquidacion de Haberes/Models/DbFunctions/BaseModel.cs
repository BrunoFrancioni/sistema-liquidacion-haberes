using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema_Liquidacion_de_Haberes.Models.DbFunctions
{
    public class BaseModel
    {
        public int PaginaActual { get; set; }
        public int TotalDeRegistros { get; set; }
        public int RegistrosPorPagina { get; set; }
    }
}