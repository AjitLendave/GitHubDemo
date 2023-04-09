using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUDusingEFDBFirstinMVC.Common1
{
    public class CustomDateRangeAttribute : RangeAttribute
    {
        public CustomDateRangeAttribute() :
        base(typeof(DateTime), DateTime.Now.ToString(), DateTime.Now.ToString())
        {
            
        }
        public override bool IsValid(object value)
        {       
            if( value != null)
            {
                DateTime inputdate = (DateTime)value;
                if (inputdate < DateTime.Now)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

    }
}