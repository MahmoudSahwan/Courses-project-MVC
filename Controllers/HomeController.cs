using CoursesMVC.Models;
using CoursesMVC.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CoursesMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        CourseContext context = new CourseContext();
        public IActionResult Index()
        {
            var viewModel = new HomeViewModel
            {
                Courses = context.Courses
                    .Include(c => c.Department)
                    .Take(6)
                    .ToList(),

                Instructors = context.Instructors
                    .Include(i => i.Department)
                    .Take(4)
                    .ToList()
            };

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
