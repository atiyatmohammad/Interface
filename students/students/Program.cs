using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Dynamic;
using System.Threading;
using System.Xml.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Net;
namespace students
{
    
    internal class Program
    {

        static HandleStudent handleStudent = new HandleStudent();
        static string query = "";
        static void Main(string[] args)
        {
            //handleStudent.ShowStudentInDataTable();
            // PressKey();
            // return;
            login();

        startprogram:
            Console.Clear();
            DisplayMenu();
            Console.WriteLine();
            Console.Write("Enter Your Selection:");
            string selectOption = Console.ReadLine().ToLower() ;

            switch(selectOption)
            {
                case "as":
                    AddStudent();
                    PressKey();
                    goto startprogram;
                case "dsl":
                    
                   // handleStudent.DisplayStudents(mylist.stList);
                    //DisplayStudents();
                    handleStudent.ShowStudents();
                   goto startprogram;
                case "ds":
                    DeleteStudent();
                    PressKey();
                    goto startprogram;
                case "us":
                    UpdateStudentGender();
                    PressKey();
                    goto startprogram;
                case "sc":
                    showstudentcount();
                    PressKey();
                    goto startprogram;
                case "EX":
                    
                default:
                    if (selectOption == "ex")
                    {
                        return;
                    }
                    else
                    {
                        goto startprogram;
                    }

                    
                
                

            }



            
           

            
            

        }
        static bool login() 
        {
        start:
            Console.Clear();
            Console.WriteLine();
            Console.Write("Enter UserName:  ");
            string userName = Console.ReadLine();

            if (userName.Length  < 5)
            {
                Console.WriteLine("Error Invalid UserName Length", -18);
                goto start;
            }
        part2:
            Console.WriteLine();
            Console.Write("Enter Password  ");
            string password = Console.ReadLine();

            if (password.Length  < 5)
            {
                Console.WriteLine("Error Invalid Gender Renter", -18);
                goto part2;
            }
            if (password != "123456" || userName != "Mohammad")
            {
                Console.WriteLine("Error Invalid Login Info  ");
                PressKey();
                goto start;
            }


            return true;
        }
        static void DisplayMenu()
        {
            Console.WriteLine("Students");
            Console.WriteLine($"AS   AddStudent",-10);
            Console.WriteLine($"DS   DeleteStudent",-10);
            Console.WriteLine($"US   UpdateStudent",-10);
            Console.WriteLine($"DSL  Display Student List",-10);
            Console.WriteLine($"SC   StudentsCount");
            Console.WriteLine($"SSS  ShowSingleStudent");
            Console.WriteLine($"1    Under construct");
            Console.WriteLine($"1    Under construct");
            Console.WriteLine($"EX    Exit");

        }
        static void AddStudent()
        {

            startaddstudent:
                
            Console.WriteLine();
                Console.Write("Enter Student Name:  ");
                string name = Console.ReadLine().ToUpper();

                if (name.Length == 0)
                  {
                      Console.WriteLine("Error Invalid Name",-18);
                      goto startaddstudent;
                  }
         part2adstudent:
            Console.WriteLine();
            Console.Write("Enter Student Gender(m:f)  ");
            string gender = Console.ReadLine().ToUpper();

            if (gender.Length == 0 && gender.Length > 1)
            {
                Console.WriteLine("Error Invalid Gender Renter", -18);
                goto part2adstudent;
            }
            handleStudent.AddStudent( name, gender); 


        }
        static void UpdateStudentGender()
        {
        start:
            Console.WriteLine();
            Console.Write("Enter Student Gender(m:f)  ");
            string gender = Console.ReadLine().ToUpper();

            if (gender.Length == 0 && gender.Length > 1)
            {
                Console.WriteLine("Error Invalid Gender Renter", -18);
                goto start;
            }
            enterid:
            Console.WriteLine();
            Console.Write("Enter Student ID:  ");
            string input = Console.ReadLine().ToUpper();
            string name = "";
            if (int.TryParse(input, out int id))
            {
                if (id > 0)
                {
                    handleStudent.UpdateStudent(id,name,gender);
                }
                else
                {
                    Console.WriteLine("Error Invalid Id Value");
                    goto enterid;
                }
            }
            else
            {

                Console.WriteLine("Error Invalid Id Value");
                goto enterid;
            }
        
        }
        static void DeleteStudent()
        {
        startaddstudent:

            Console.WriteLine();
            Console.Write("Enter Student ID:  ");
            string input = Console.ReadLine().ToUpper();

            if (int.TryParse(input, out int id))
            {
                if (id > 0)
                {
                    handleStudent.deleteStudent(id);
                }
                else
                {
                    Console.WriteLine("Error Invalid Id Value");
                    goto startaddstudent;
                }
            }else {
            
                Console.WriteLine("Error Invalid Name Value");
                goto startaddstudent;
            }
        }
        static void showstudentcount()
        {
            Console.WriteLine("________________________________________________________________");
            query = "select count(id) as Studentcount from student ";
            
            handleStudent.ShowStudentcount(query);
            query = "select count(gender) as MaleeStudentsCount from student where gender = 'M'";
            handleStudent.ShowStudentcount(query);
            query = "select count(gender) as FemaleStudentsCount from student where gender = 'F'";
            handleStudent.ShowStudentcount(query);
        }
        static void DisplayStudents()
        {
            // sList = new StudentList();
           //dynamic row = new ExpandoObject();
          //for (int l=0; sList.studentlist.Length; l++ )
         // foreach (Student student in sList.studentlist ) 
           // {
          //      Console.WriteLine($"{student.Id } {student.Name } {student.Gender }");
          // }
        }
        static void PressKey()
        {
            Console.Write("Press <Enter> to exit... ");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
        }



    }
}
