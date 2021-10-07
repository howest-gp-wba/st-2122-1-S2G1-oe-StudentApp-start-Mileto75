using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wba.Oefening.Students.Core;
using Wba.Oefening.Students.Web.ViewModels;

namespace Wba.Oefening.Students.Web.Controllers
{
    public class CoursesController : Controller
    {
        private readonly CourseRepository _courseRepository;

        public CoursesController()
        {
            _courseRepository = new CourseRepository();
        }
        public IActionResult Courses()
        {
            IEnumerable<CoursesCoursesViewModel> coursesCoursesViewModels
                = _courseRepository.Courses
                .Select(c => new CoursesCoursesViewModel {
                    Id = c?.Id ?? 0,
                    Title = c?.Name ?? "<NoTitle>"
                });

            return View(coursesCoursesViewModels);
        }
    }
}
