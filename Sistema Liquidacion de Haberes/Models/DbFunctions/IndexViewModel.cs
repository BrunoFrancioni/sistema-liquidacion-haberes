using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema_Liquidacion_de_Haberes.Models.DbFunctions
{
    public class IndexViewModel : BaseModel
    {
        public IEnumerable<ViewModelEmployee> Empleados { get; set; }
    }
}