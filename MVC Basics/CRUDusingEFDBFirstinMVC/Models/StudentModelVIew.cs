using CRUDusingEFDBFirstinMVC.Common1;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDusingEFDBFirstinMVC.Models
{   
    [MetadataType(typeof(studentMetadata))]
    public partial class student
    {

        [Required(ErrorMessage = "Confirm Email is Required")]
        [System.ComponentModel.DataAnnotations.Compare("email", ErrorMessage = "Email & Confirm Email should be same")]
        [Display(Name = "Confirm Email")]
        public string ConfirmEmail { get; set; }
    }

    public class studentMetadata
    {
        public int RollNo { get; set; }

        [Required (ErrorMessage = "Student Name is Requiered")]
        [StringLength (15 , MinimumLength = 3, ErrorMessage ="Name should have Minimum 3 and Maximum 15 charactors")]
        [RegularExpression("[a-zA-Z ]+$", ErrorMessage = "Student name should contain only alphabets")]
        [Display(Name = "Student Name")]
        [Remote("IsNameExists", "students", ErrorMessage = " Name Already Exist")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Age is Requiered")]
        [Range(10, 40, ErrorMessage = "Age should be in between 10 and 40")]
        public Nullable<int> Age { get; set; }

        [Required(ErrorMessage = "Email is Requiered")]
        [RegularExpression("[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)" +
            "*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Please enter valid email")]
        [Display (Name = "Email Id")]
        public string email { get; set; }

        [Required(ErrorMessage = "DoB is Requiered")]
        //[DataType(DataType.Date, ErrorMessage = "Please Enter valid DoB")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Date of Birth")]
        [CustomDateRangeAttribute (ErrorMessage = "DoB should be less than today's date")]
        public Nullable<System.DateTime> DoB { get; set; }
       
        [Display(Name ="City")]
        public string city { get; set; }

        [Display(Name = "Trainer Id")]
        public Nullable<int> TrainerId { get; set; }

        public virtual Trainer Trainer { get; set; }
    }

}
