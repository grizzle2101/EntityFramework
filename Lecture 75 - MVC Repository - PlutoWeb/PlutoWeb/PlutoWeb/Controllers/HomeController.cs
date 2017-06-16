using PlutoWeb.Core;
using PlutoWeb.Core.Domain;
using PlutoWeb.Persistence;
using System;
using System.Linq;
using System.Web.Mvc;

namespace PlutoWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        PlutoContext context;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            context = new PlutoContext();
        }

        public ActionResult Index()
        {
            //Bad Way
            //var Courses = context.Courses.ToList();
            //return View(Courses);
            
            //Proper Way - Using Unit of Work
            var courses = _unitOfWork.Courses.GetAll();
            return View(courses);
        }

        [HttpPost]
        public ActionResult AddCourse()
        {
            ////Bad Way
            //context.Courses.Add(new Course
            //{
            //    Name = "New Course at " + DateTime.Now.ToShortDateString(),
            //    Description = "Description",
            //    AuthorId = 1,
            //    FullPrice = 49,
            //    Level = 1
            //});
            //context.SaveChanges();

            //Proper Way - Using UnitOfWork
            _unitOfWork.Courses.Add(new Course
            {
                Name = "New Course at " + DateTime.Now.ToShortDateString(),
                Description = "Description",
                AuthorId = 1,
                FullPrice = 49,
                Level = 1
            });

            _unitOfWork.Complete();
            
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        //Dispose no Longer needed as we're using Dependency Framework to Resolve this.
        //public override void Dispose
        //{

        //}

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}