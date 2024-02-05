using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Models
{
    internal class Courses
    {
        public int CoursesID { get; set; }

        public string CourseName { get; set; }
        public string CourseDescription { get; set; }

        //first way to many to many relation 
        // public virtual ICollection<Student> Students { get; set; }
    }
}
