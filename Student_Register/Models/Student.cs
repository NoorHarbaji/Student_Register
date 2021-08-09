using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student_Register.Models
{
    public class Student 
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Column("FirstName")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Gender { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Number")]
        public int Contact { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Inst")]
        public string PersonIdentity { get; set; }

        public int? BatchID { set; get; }
        public Batch Batch { get; set; }
        public virtual List<Record> Records { get; set; }
    }
}
