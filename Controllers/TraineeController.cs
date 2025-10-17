using CoursesMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoursesMVC.Controllers
{
    public class TraineeController : Controller
    {
        CourseContext context = new CourseContext();
        public IActionResult Index()
        {
            var TraineeList = context.Traines.ToList();

            return View("Index",TraineeList);
        }
        public IActionResult Details(int id) 
        {
            Trainee trainee = context.Traines.FirstOrDefault(t=>t.Id==id);
            return View("Details", trainee);
        }

        public IActionResult New()
        {
            ViewBag.Departments = new SelectList(context.Departments.ToList(), "Id", "Name");

            return View("New");
        }
        public IActionResult SaveNew(Trainee TraineeFromRequest)
        {
            if (TraineeFromRequest.Name != null && TraineeFromRequest.Grade != null)
            {
                context.Traines.Add(TraineeFromRequest);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("New", TraineeFromRequest);
        }
    }
}
