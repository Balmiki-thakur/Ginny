using System.Diagnostics;
using System.Web;
using System.Web.Mvc;

namespace Reliance
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
           
        }
    }
}