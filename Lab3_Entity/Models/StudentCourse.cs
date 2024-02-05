using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Models
{
    internal class StudentCourse
    {
        [Key]
        public int RelatedCourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int StudentId { get; set;}

        public int CoursesId { get; set; }
        public virtual Courses Courses { get; set; }

        public virtual Student Student { get; set; }
    }
}
