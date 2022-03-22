using System.Web;
using System.Web.Mvc;

namespace Asp.Net_CRUD_program
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
