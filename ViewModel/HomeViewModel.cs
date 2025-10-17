using CoursesMVC.Models;

namespace CoursesMVC.ViewModel
{
    public class HomeViewModel
    {
        public List<Course> Courses { get; set; }
        public List<Instructor> Instructors { get; set; }
    }
}
