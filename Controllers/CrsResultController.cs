using CoursesMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; 

namespace CoursesMVC.Controllers
{
    public class CrsResultController : Controller
    {
        CourseContext context = new CourseContext();

        public IActionResult Index()
        {
            var CrsRsltList = context.Results
                .Include(r => r.Trainee)
                    .ThenInclude(t => t.Department)
                .Include(r => r.Course)
                .ToList();

            return View("Index", CrsRsltList);
        }

        public IActionResult Details(int id)
        {
            var CrsResult = context.Results
                .Include(r => r.Trainee)
                    .ThenInclude(t => t.Department)
                .Include(r => r.Course)
                .FirstOrDefault(r => r.Id == id);

            if (CrsResult == null)
                return NotFound();

            return View("Details", CrsResult);
        }
    }
}
