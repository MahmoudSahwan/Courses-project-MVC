using System.ComponentModel.DataAnnotations.Schema;

namespace CoursesMVC.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { set; get; }
        public string Img { set; get; } 
        public int Salary { set; get; }
        public string address { set; get; }

        [ForeignKey("Department")]
        public int DepartmentID { get; set; } // foreignkey
        public Department Department { set; get; } //navigator

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course Course { set; get; }

    }
}
