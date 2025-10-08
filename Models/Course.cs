using System.ComponentModel.DataAnnotations.Schema;

namespace CoursesMVC.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Degree { get; set; }
        public int MinDegree { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}
