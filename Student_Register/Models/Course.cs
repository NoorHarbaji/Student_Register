using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student_Register.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        [Range(0, 5)]
        public int Duration { get; set; }
        public string CourseName { get; set; }

        public int StaffId { set; get; }
        public int BatchId { get; set; }

        [ForeignKey("BatchId")]
        public Batch Batch { get; set; }
        [ForeignKey("StaffId")]
        public Staff Staff { set; get; }
        public ICollection<Record> Records { get; set; }
    }
}
