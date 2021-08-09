using System.ComponentModel.DataAnnotations;

namespace Student_Register.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }
    public class Record

    {
        public int ID { get; set; }
        public virtual int StudentID { get; set; }
        public virtual int CourseID { get; set; }
        [DisplayFormat(NullDisplayText = "No grade")]
        public Grade? Grade { get; set; }
        public virtual Student Student { set; get; }
        public virtual Course Course { get; set; }

    }

}

