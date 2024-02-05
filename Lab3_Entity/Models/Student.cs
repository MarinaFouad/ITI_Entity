using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Models
{
    internal class Student
    {
        public int StudentID { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }
        public string Address { get; set; }

        public virtual Department Department { get; set; }
        [ForeignKey("Department")]
        public int DepatID { get; set; }


        //first way to many to many relation 
       // public virtual ICollection<Courses> Courses { get; set; }





    }
}
