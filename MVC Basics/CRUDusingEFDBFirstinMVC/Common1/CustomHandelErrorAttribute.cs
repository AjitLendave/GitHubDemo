using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDusingEFDBFirstinMVC.Common1
{
    public class CustomHandelErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {  
            //Write ADO.Net code for insertion of exception to database

            base.OnException(filterContext);
        }
    }
}