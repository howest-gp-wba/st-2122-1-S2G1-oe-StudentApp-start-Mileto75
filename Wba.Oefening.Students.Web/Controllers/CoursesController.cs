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
        private readonly StudentRepository _studentRepository;

        public CoursesController()
        {
            _courseRepository = new CourseRepository();
            _studentRepository = new StudentRepository();
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

        public IActionResult GetStudentsByCourseId(int courseId)
        {
            //declare the model
            CoursesGetStudentsByCourseIdViewModel
                coursesGetStudentsByCourseIdViewModel =
                new CoursesGetStudentsByCourseIdViewModel();
            //get the students and fill the model
            coursesGetStudentsByCourseIdViewModel.Students
                = _studentRepository
                .GetStudentsInCourseId(courseId)
                .Select(s => new StudentStudentInfoViewModel
                {
                    Id = s?.Id ??0,
                    StudentName = $"{s?.FirstName??"<>"} {s?.LastName??"<>"}"
                });
            //get the courseName
            coursesGetStudentsByCourseIdViewModel
                .CourseName = _courseRepository.GetCourseById(courseId)
                .Name;
            //Pass to view
            return View(coursesGetStudentsByCourseIdViewModel);
        }
    }


}
