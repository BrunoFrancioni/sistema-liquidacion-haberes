using System.Web;
using System.Web.Mvc;

namespace Sistema_Liquidacion_de_Haberes
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
