using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student_Register.Models
{
    public class Batch
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string year { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
