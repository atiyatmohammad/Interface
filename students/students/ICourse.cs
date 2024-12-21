using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace students
{
    internal interface ICourse
    {
        void AddScore(int id,  string courseName);
        void DeleteScore(int id);
        void DisplayCourses();
        void UpdataCourse(int id,string courseName);
        void DisplayCoursesTextFile(string courseName);

    }
}
