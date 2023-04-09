using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUDusingEFDBFirstinMVC.Models
{
    [MetadataType(typeof(TrainerMetadata))]
    public partial class Trainer
    {

    }

    public class TrainerMetadata
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Trainer Name is Requiered")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Name should have Minimum 3 and Maximum 15 charactors")]
        [RegularExpression("[a-zA-Z ]+$", ErrorMessage = "Trainer name should contain only alphabets")]
        [Display(Name = "Trainer Name")]
        public string Name { get; set; }

        public virtual ICollection<student> students { get; set; }
    }
}