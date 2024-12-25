using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace students
{
    internal interface ICourse
    {
        void AddCourse(string courseName);
        void DeleteCourse(int id);
        void DisplayCourses(string query);
        void UpdataCourse(int id,string courseName);
        void DisplayCoursesTextFile(string query);

    }
}
