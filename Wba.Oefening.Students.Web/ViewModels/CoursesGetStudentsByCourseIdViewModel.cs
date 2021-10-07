using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wba.Oefening.Students.Web.ViewModels
{
    public class CoursesGetStudentsByCourseIdViewModel
    {
        public string CourseName { get; set; }
        public IEnumerable<StudentStudentInfoViewModel> 
            Students { get; set; }
    }
}
