using System.Collections.Generic;

namespace Student_Register.Models.ViewModels
{
    public class BatchCourse
    {
        public Batch Batch { set; get; }
        public List<Course> Courses { set; get; }
    }
}
