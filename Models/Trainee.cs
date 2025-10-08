using System.ComponentModel.DataAnnotations.Schema;

namespace CoursesMVC.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public int Image { get; set; }
        public string Grade { get; set; }
        public string Address { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
