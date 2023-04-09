using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentAPIClient.Models
{
    public class Student
    {
        public int RollNo { get; set; }
        public string Name { get; set; }
        public Nullable<int> Age { get; set; }
        public string Gender { get; set; }
    }
}