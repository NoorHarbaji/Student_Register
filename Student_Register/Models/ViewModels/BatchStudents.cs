using System.Collections.Generic;

namespace Student_Register.Models.ViewModels
{
    public class BatchStudents
    {
        public Batch Batch { set; get; }
        public List<Student> Students { set; get; }
    }
}
