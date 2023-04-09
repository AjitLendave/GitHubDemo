using CRUDusingEFDBFirstinMVC.Common1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDusingEFDBFirstinMVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new CustomHandelErrorAttribute());  //For all Cotrollers
        }
    }
}