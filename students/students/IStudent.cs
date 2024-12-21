using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace students
{
    internal interface IStudent
    {
        //dynamic st = new List<dynamic>();
        
        void AddStudent(string name,string gender);
      
        void DisplayStudents(List<Student> ls);
        void UpdateStudent(int id,string name,string gender);

        void deleteStudent(int id);
        void ShowStudentcount(string query);
        //void AddList();
        void ShowSingleStudent(int id);
    }
}
