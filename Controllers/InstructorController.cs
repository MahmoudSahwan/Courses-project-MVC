using CoursesMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoursesMVC.Controllers
{
    public class InstructorController : Controller
    {
        CourseContext context = new CourseContext();
        public IActionResult Index()
        {
            var EmpList = context.Instructors.ToList();
            return View("Index", EmpList);
        }

        public IActionResult Details(int id)
        {
            Instructor Ins = context.Instructors.FirstOrDefault(i => i.Id == id);
            return View("Details", Ins);
        }

    }
}
