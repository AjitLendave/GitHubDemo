using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MVC_Basics.Models
{
    public class Student
    {
        [DisplayName("Student Name")]
        public string Name { get; set; }

        [DisplayName("Student Email")]
        public string Email { get; set; }
    }
}