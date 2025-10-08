using CoursesMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoursesMVC.Controllers
{
    public class CourseController : Controller
    {
        CourseContext Context = new CourseContext();
        public IActionResult Index()
        {
            var CrsList = Context.Courses.ToList();
            return View("Index",CrsList);
        }
        public IActionResult Details(int id) 
        {
            Course crs = Context.Courses.FirstOrDefault(c => c.Id == id);
            return View("Details",crs);
         }
    }
}
