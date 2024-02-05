using Lab2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer;
using System.Linq;


namespace Lab2
{
    public partial class Form1 : Form
    {
        UniDatabaseContext uniDatabaseContext = new UniDatabaseContext();
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            var StudentSet = uniDatabaseContext.Students.Include(a => a.Department)
                .Select(s => new { ID = s.StudentId, Name = $"{s.FirstName} { s.LastName }", Department = s.Department.DepartmentName, Age = s.Age }).ToList();
            dataGridView1.DataSource = StudentSet;


            comboBox1.Items.Add("Computer Science");
            comboBox1.Items.Add("Mathematics");
            comboBox1.Items.Add("Physics");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Student Student01 = new Student();
            Student01.StudentId = int.Parse(textBox2.Text);
            Student01.FirstName = textBox3.Text;
            Student01.LastName = textBox4.Text;
            var SelectedDep = comboBox1.SelectedItem.ToString();
            Department department01 = uniDatabaseContext.Departments.Where(a => a.DepartmentName == SelectedDep).FirstOrDefault();
            Student01.Department = department01;
            uniDatabaseContext.Students.Add(Student01);
            uniDatabaseContext.SaveChanges();
            Form1_Load(sender, e);
        }




        private void button4_Click(object sender, EventArgs e)
        {
            var DeleteStu = 0;
            if (dataGridView1.SelectedRows.Count > 0)
            {

                DeleteStu = (int)dataGridView1.SelectedRows[0].Cells["ID"].Value;
                deleteStudet(DeleteStu);
                Form1_Load(sender, e);
            }


            else if ((textBox2.Text) != "")
            {

                DeleteStu = int.Parse(textBox2.Text);
                deleteStudet(DeleteStu);
                Form1_Load(sender, e);


            }
            else
            {
                MessageBox.Show("Please select ID");
            }
        }
        private void deleteStudet(int D)
        {
            Student Remove01 = uniDatabaseContext.Students.Include(s => s.Courses).Where(s => s.StudentId == D).Single();

            foreach (var course in Remove01.Courses.ToList())
            {
                Remove01.Courses.Remove(course);
            }

            uniDatabaseContext.Students.Remove(Remove01);
            uniDatabaseContext.SaveChanges();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Search01 = textBox1.Text;
            var StudentSearch = uniDatabaseContext.Students.Include(a => a.Department)
                .Where(s => s.FirstName.ToLower().Contains(Search01) || s.LastName.ToLower().Contains(Search01))
                .Select(s => new { ID = s.StudentId, Name = s.FirstName, Department = s.Department.DepartmentName, Age = s.Age }).ToList();
            dataGridView1.DataSource = StudentSearch;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1_Load(sender, e);
        }
    }



}
