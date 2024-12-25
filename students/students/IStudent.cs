using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace students
{
    internal interface IStudent
    {
               
        void AddStudent(string name,string gender);
      
       
        void UpdateStudent(int id,string name,string gender);

        void deleteStudent(int id);
        void ShowStudentcount(string query);
        void DisplayMenu();
        
        
    }
}
