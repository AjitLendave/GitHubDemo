using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDusingADO.NETinMVC.Models
{
    public class Student
    {
        public int? RollNo { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public string Email { get; set; }
        public DateTime? DoB { get; set; }
        public string City { get; set; }
        public int? TrainerId { get; set; }
    }
}