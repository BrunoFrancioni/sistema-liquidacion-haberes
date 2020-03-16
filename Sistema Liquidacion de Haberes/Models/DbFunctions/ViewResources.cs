using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sistema_Liquidacion_de_Haberes.Models.DbModels;

namespace Sistema_Liquidacion_de_Haberes.Models.DbFunctions
{
    public class ViewResources
    {
        public string ObtenerObraSocial(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var obraSocial = db.obrasSociales.Where(obra => obra.idObrasSociales == id);

                string nombreObraSocial = obraSocial.Select(obra => obra.nombre).ToString();

                return nombreObraSocial;
            }
        }

        public string ObtenerSector(int idCategoria)
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                var categoria = db.categorias.Single(cat => cat.idCategorias == idCategoria);

                int idSector = categoria.sector_idSector;

                var sector = db.sectores.Where(obtenerSector => obtenerSector.idSector == idSector);

                string nombreSector = sector.Select(s => s.nombre).ToString();

                return nombreSector;
            }
        }

        public string ObtenerCategoria(int id)
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                var categoria = db.categorias.Where(cat => cat.idCategorias == id);

                string nombreCategoria = categoria.Select(cat => cat.nombre).ToString();

                return nombreCategoria;
            }
        }
    }
}