using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Lab;
namespace Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region task 1 

            // Query 1

            List<int> numbers = new List<int>() { 2, 4, 6, 7, 1, 4, 2, 9, 1 };
            var NoReapet = numbers.Distinct().OrderBy(x => x).ToList();
            foreach (var number in NoReapet)
            {
                Console.WriteLine(number);
            }

            // Query 2 

            var Multy = NoReapet.Select(num=> new { Number = num, Multiplication = num * num }).ToList();
            foreach(var number in Multy)
            { Console.WriteLine(number); }

            Console.WriteLine("-------------");

            #endregion

            #region task2

            string[] names = { "Tom", "Dick", "Harry", "MARY", "Jay" }; 
            //1
            //By Query 

            var Query1 = from name in names  where name.Length == 3 select name; 
            foreach (var name in Query1)
            {  Console.WriteLine(name); }

            Console.WriteLine("-------------"); 

            //By Method 
            var Method1 = names.Where(name=>name.Length == 3).ToList();
            foreach ( var name in Method1)
            { Console.WriteLine(name); }

            Console.WriteLine("-------------");
            //2
            //By Query
            var Query2 = from name in names
                         where name.ToLower().Contains("a")
                         orderby name.Length
                         select name;
            foreach(var name in Query2)
            { Console.WriteLine(name); }

            Console.WriteLine("-------");
            //By Method 
            var Method2 = names.Where(name=>name.ToLower().Contains("a")).OrderBy(name=>name.Length).ToList();
            foreach( var name in Method2)
            { Console.WriteLine(name); }
            Console.WriteLine("-------");
            //3 


            var Query3 = (from name in names select name).Take(2);
            foreach (var name in Query3)
            { Console.WriteLine(name); }

            Console.WriteLine("-------");
            //By Method 

            var Method3 = names.Select(name => name).Take(2) ;
            foreach (var name in Method3)
            { Console.WriteLine(name); }

            Console.WriteLine("-------------");
            #endregion


            #region Task 3

            #region Data

            List<Student> students = new List<Student>()
        {
            new Student
            {
                ID = 1,FirstName = "Ali", LastName = "Mohammed",
                Subjects = new Subject[]
                {
                    new Subject { Code = 22, Name = "EF" },
                    new Subject { Code = 33, Name = "UML" }
                }
            },
            new Student
            {
                ID = 2, FirstName = "Mona", LastName = "Gala",
                Subjects = new Subject[]
                {
                    new Subject { Code = 22, Name = "EF" },
                    new Subject { Code = 34, Name = "XML" },
                    new Subject { Code = 25, Name = "JS" }
                }
            },
            new Student
            {
                ID = 3, FirstName = "Yara", LastName = "Yousf",
                Subjects = new Subject[]
                {
                    new Subject { Code = 22, Name = "EF" },
                    new Subject { Code = 25, Name = "JS" }
                }
            },
            new Student
            { ID = 4, FirstName = "Ali", LastName = "Ali",
                Subjects = new Subject[]
                {
                    new Subject { Code = 33, Name = "UML" }
                }
            }
        };
            #endregion

            //Query 1

            var QueryTask03 = students.Select(s => new
            {
                FullName = $"{s.FirstName} {s.LastName}",
                NoOfSubjects = s.Subjects.Length
            });

            foreach (var s in QueryTask03)
             {
              Console.WriteLine($"Full Name: {s.FullName}," +
                  $" Number of Subjects: {s.NoOfSubjects}");
             }

            Console.WriteLine("--------------");

            //Query 2

            var QueryTask13 = students.OrderByDescending(s => s.FirstName)
            .ThenBy(s => s.LastName)
            .Select(s => $"{s.FirstName} {s.LastName}");

            foreach (var s in QueryTask13)
            { Console.WriteLine(s); }

            Console.WriteLine("--------------");

            //Query 3

            var QueryTask23 = students.SelectMany(s => s.Subjects, (s, subj) =>
                new
                {
                    StudentName = $"{s.FirstName} {s.LastName}",
                    SubjectName = subj.Name
                });
            foreach(var s in QueryTask23)
            { Console.WriteLine(s); }

            Console.WriteLine("--------------");

            

            #endregion


        }
    }
}
