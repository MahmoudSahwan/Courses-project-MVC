using CoursesMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoursesMVC.Controllers
{
    public class DepartmentController : Controller
    {
        CourseContext context = new CourseContext();
        public IActionResult Index()
        {
            var deptList = context.Departments.ToList();
            return View("Index",deptList);
        }
        public IActionResult Details(int id) 
        {
            Department dept = context.Departments.FirstOrDefault(d => d.Id == id);
             return View("Details",dept);
        }
        
        public IActionResult New()
        {
            return View("New");
        }

        [HttpPost]
        public IActionResult SaveNew(Department deptFromReq) 
        {
         if(deptFromReq.Name != null&& deptFromReq.Manger !=null)
            {
                context.Departments.Add(deptFromReq);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("New",deptFromReq);
        }
    }
}
