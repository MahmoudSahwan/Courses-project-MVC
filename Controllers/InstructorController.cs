using CoursesMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        public IActionResult New() 
        {
            ViewBag.Courses = new SelectList(context.Courses.ToList(),"Id","Name") ;
            ViewBag.Departments = new SelectList(context.Departments.ToList(), "Id", "Name");

            return View("New"); 
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveNew(Instructor InsFromRequest)
        {
            if (InsFromRequest.Name != null && InsFromRequest.Salary >7000)
            {
                context.Instructors.Add(InsFromRequest);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("New",InsFromRequest);
        }

        public IActionResult Edit(int id) 
        {
            Instructor insFromDb = context.Instructors.FirstOrDefault(i => i.Id == id);
            ViewBag.Courses = new SelectList(context.Courses.ToList(), "Id", "Name");
            ViewBag.Departments = new SelectList(context.Departments.ToList(), "Id", "Name");
            return View("Edit", insFromDb);
        }
        public IActionResult SaveEdit(Instructor InsFromRequest)
        {
            if(InsFromRequest.Name != null)
            {
                //get old ref
                Instructor insFromDb = context.Instructors.FirstOrDefault(i => i.Id == InsFromRequest.Id);

                //change model
                insFromDb.Name = InsFromRequest.Name;
                insFromDb.Img = InsFromRequest.Img;
                insFromDb.Salary = InsFromRequest.Salary;
                insFromDb.address = InsFromRequest.address;
                insFromDb.DepartmentID = InsFromRequest.DepartmentID;
                insFromDb.CourseId = InsFromRequest.CourseId;


                // save db
                context.SaveChanges();
                //return index
                return RedirectToAction("Index", "Instructor");


            }

            return View("Edit",InsFromRequest);
        }


        

       

    }
}
