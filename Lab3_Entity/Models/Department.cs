using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Models
{
    internal class Department
    {
        public int DepartmentID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Student> Students { get; set; } 
    }
}
