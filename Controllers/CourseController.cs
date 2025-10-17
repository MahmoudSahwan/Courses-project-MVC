using CoursesMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        public IActionResult New()
        {
            ViewBag.Departments = new SelectList(Context.Departments.ToList(), "Id", "Name");

            return View("New");
        }
        public IActionResult SaveNew(Course crsFromRequest)
        {
            if (crsFromRequest.Name != null && crsFromRequest.Degree != null)
            {
                Context.Courses.Add(crsFromRequest);
                Context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("New", crsFromRequest);
        }
    }
}
