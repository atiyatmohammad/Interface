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
using System.ComponentModel.Design;


namespace students
{
    
    internal class Program
    {
    
        static Student Student = new Student();
        //static Student student = new Student();
        static Course course = new Course();
        static Score score = new Score();
                 
        static string query = "";

        public static object Get { get; private set; }

        static void Main(string[] args)
        {

            //Directory1();
               
            //Student.ShowStudentInDataTable();
            // PressKey();
            // return;
            login();

        startprogram:
            Console.Clear();
            DisplayMenu();
            Console.WriteLine();
            string str = "";
            Console.Write($"{str,5} Enter Your Selection: ");
            string selectOption = Console.ReadLine().ToLower() ;

            switch(selectOption)
            {
                case "as":
                    AddStudent();
                    PressKey();
                    goto startprogram;
                case "dsl":
                  DisplayStudents();
                    
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
                case "sss":
                    ShowStudentByIdNo();
                    PressKey();
                    goto startprogram;
                case "ac":
                    AddCourse();
                    PressKey();
                    goto startprogram;
                case "dsc":
                    DisplayCoursess();
                    goto startprogram;
                case "dc":
                    DeleteCourse();
                    PressKey();
                    goto startprogram;
                case "uc":
                    UpdateCourseName();
                    PressKey();
                    goto startprogram;
                case "dctf":
                    DisplayCourseTextFile();
                   // PressKey();
                    goto startprogram;
                case "ass":
                    AddScore();
                    PressKey();
                    goto startprogram;
                case "dsss":
                    DisplayScore();
                    goto startprogram;
                case "dss":
                    DeleteScore();
                    PressKey();
                    goto startprogram;
                case "uss":
                    UpdateScoreStudentId();
                    PressKey();
                    goto startprogram;
                case "usc":
                    UpdateScoreCourseId();
                    PressKey();
                    goto startprogram;
                case "usg":
                    UpdateScoreGrade();
                    PressKey();
                    goto startprogram;
                case "dsstf":
                    DisplayScoreTextFile();
                    // PressKey();
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
            Console.Write("                                    Enter User Name:  ");
            string userName = Console.ReadLine();

            if (userName.Length  < 5)
            {
                Console.WriteLine("Error Invalid UserName Length", -10);
                goto start;
            }
        part2:
            Console.WriteLine();
            Console.Write("                                     Enter Password  ");
            string password = Console.ReadLine();

            if (password.Length  < 5)
            {
                Console.WriteLine("Error Invalid Gender Renter", -10);
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
            string str = " ";
            Console.WriteLine("SCHOOL");
            Console.WriteLine($"{str,-25}  AS    AddStudent {str,-10}           AC   Add Course");
            Console.WriteLine($"{str,-25}  DS    DeleteStudent {str,-10}        UC   Update Course");
            Console.WriteLine($"{str,-25}  US    UpdateStudent {str,-10}        DC   Delete Course");
            Console.WriteLine($"{str,-25}  DSL   Display Student List {str,-10} DSC  Display Courses");
            Console.WriteLine($"{str,-25}  SC    StudentsCount {str,-10}        DCTF Display Courses Text File");
            Console.WriteLine($"{str,-25}  SSS   Search Student By Id");
            
            Console.WriteLine();
            Console.WriteLine($"{str,-44}  ASS   Add Student Score");
            Console.WriteLine($"{str,-44}  USS   Update Score StudentId");
            Console.WriteLine($"{str,-44}  USC   Update Score CourseId");
            Console.WriteLine($"{str,-44}  USG   Update Score Grade");
            Console.WriteLine($"{str,-44}  DSS   Delete Student Score");
            Console.WriteLine($"{str,-44}  DSSS  Display Student Scores");
            Console.WriteLine($"{str,-44}  DSSTF Display Student Score Text File");
            Console.WriteLine($"{str,-44}  EX    Exit Programm");


        }
        static void AddStudent()
        {

            startaddstudent:
                
            Console.WriteLine();
                Console.Write("Enter Student Name:  ");
                string name = Console.ReadLine().ToUpper();

                if (name.Length == 0)
                  {
                      Console.WriteLine("Error Invalid Name",-10);
                      goto startaddstudent;
                  }
         part2adstudent:
            Console.WriteLine();
            Console.Write("Enter Student Gender(m:f)  ");
            string gender = Console.ReadLine().ToUpper();

            if (gender.Length == 0 && gender.Length > 1)
            {
                Console.WriteLine("Error Invalid Gender Renter", -10);
                goto part2adstudent;
            }
            Student.AddStudent( name, gender); 


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
                    Student.deleteStudent(id);
                }
                else
                {
                    Console.WriteLine("Error Invalid Id Value");
                    goto startaddstudent;
                }
            }
            else
            {

                Console.WriteLine("Error Invalid Name Value");
                goto startaddstudent;
            }
        }
        static void UpdateStudentGender()
        {
        start:
            Console.WriteLine();
            Console.Write("Enter Student Gender(m:f)  ");
            string gender = Console.ReadLine().ToUpper();

            if (gender.Length == 0 && gender.Length > 1)
            {
                Console.WriteLine("Error Invalid Gender Renter", -10);
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
                    Student.UpdateStudent(id, name, gender);
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
        
        
        static void showstudentcount()
        {
            Console.WriteLine("________________________________________________________________");
            query = "select count(id) as Studentcount, (select count(gender)  from student where gender = 'M') as MaleStudents  \r\n ,(select count(gender)  from student where gender = 'F') as FemaleStudents  from student";
            Student.ShowStudents(query);

        }
        static void DisplayStudents()
        {
            {
                query = "select *  from student";
                Student.ShowStudents(query);
            }
        }
        static void ShowStudentByIdNo()
        {
        startaddstudent:

            Console.WriteLine();
            Console.Write("Enter Student ID:  ");
            string input = Console.ReadLine().ToUpper();

            if (int.TryParse(input, out int id))
            {
                if (id > 0)
                {
                    query = $"select * from student where id = {id}";
                    Student.ShowStudents(query);
                }
                else
                {
                    Console.WriteLine("Error Invalid Id Value");
                    goto startaddstudent;
                }
            }
            else
            {

                Console.WriteLine("Error Invalid Name Value");
                goto startaddstudent;
            }
        }
        static void AddCourse()
        {

        startaddcourse:

            Console.WriteLine();
            Console.Write("Enter Course Name:  ");
            string courseName = Console.ReadLine().ToUpper();

            if (courseName.Length == 0)
            {
                Console.WriteLine("Error Invalid Name", -10);
                goto startaddcourse;
            }

            course.AddCourse(courseName);


        }
        static void UpdateCourseName()
        {
        enterid:
            Console.WriteLine();
            Console.Write("Enter Course ID:  ");
            string input = Console.ReadLine().ToUpper();

            if (int.TryParse(input, out int id))
            {
                if (id > 0)
                {
                    goto start;
                }
                else
                {
                    Console.WriteLine("Error Invalid Course Id Value");
                    goto enterid;
                }
            }
            else
            {

                Console.WriteLine("Error Invalid Course Id Value");
                goto enterid;
            }
        start:
            Console.WriteLine();
            Console.Write("Enter New Course Name  ");
            string courseName = Console.ReadLine().ToUpper();

            if (courseName.Length == 0)
            {
                Console.WriteLine("Error Invalid Course Name Renter", -10);
                goto start;
            }
            else
            {
                course.UpdataCourse(id, courseName);
            }



        }
        static void DeleteCourse()
        {
        startaddstudent:

            Console.WriteLine();
            Console.Write("Enter Course ID:  ");
            string input = Console.ReadLine().ToUpper();

            if (int.TryParse(input, out int id))
            {
                if (id > 0)
                {
                    course.DeleteCourse(id);
                }
                else
                {
                    Console.WriteLine("Error Invalid Course Id Value");
                    goto startaddstudent;
                }
            }
            else
            {

                Console.WriteLine("Error Invalid Course Id Value");
                goto startaddstudent;
            }
        }
        
        static void DisplayCoursess()
        {
            query = "select *  from course";
            course.DisplayCourses(query);
        }
        static void PressKey()
        {
            Console.Write("Press <Enter> to exit... ");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
        }

        static void DisplayCourseTextFile()
        {
       
            query = "select * from course";
            course.DisplayCoursesTextFile(query);
        }
        static void AddScore()
        {

        enterstudentid:
            Console.WriteLine();
            Console.Write("Enter studentId:  ");
            string input = Console.ReadLine().ToUpper();

            if (int.TryParse(input, out int studentId))
            {
                if (studentId > 0)
                {
                    goto entercourseid;
                }
                else
                {
                    Console.WriteLine("Error You Entered Invalid StudentId Value");
                    goto enterstudentid;
                }
            }
            else
            {

                Console.WriteLine("Error Invalid StudentId Value");
                   goto enterstudentid;
                
            }
        entercourseid:
            Console.WriteLine();
            Console.Write("Enter CourseId:  ");
            string input1 = Console.ReadLine().ToUpper();

            if (int.TryParse(input1, out int courseId))
            {
                if (courseId > 0)
                {
                    goto entergrade;
                }
                else
                {
                    Console.WriteLine("Error You Entered Invalid Student Id Value");
                    goto entercourseid;
                }
            }
            else
            {

                Console.WriteLine("Error Invalid Course Id Value");
                goto entercourseid;
            }
        entergrade:
            Console.WriteLine();
            Console.Write("Enter Student Grade:  ");
            string input2 = Console.ReadLine().ToUpper();
            
            if (float.TryParse(input2, out float grade))
            {
                if (grade > 0)
                {
                    score.AddScore(studentId,courseId,grade);
                }
                else
                {
                    Console.WriteLine("Error You Entered Invalid Grade Value");
                    goto entergrade;
                }
            }
            else
            {

                Console.WriteLine("Error Invalid Grade Value");
                goto entergrade;
            }

            


        }
        static void UpdateScoreStudentId()
        {
         enterscoreid:
            Console.WriteLine();
            Console.Write("Enter ScoreID:  ");
            string input1 = Console.ReadLine().ToUpper();

            if (int.TryParse(input1, out int scoreid))
            {
                if (scoreid > 0)
                {
                    goto enterstudentid;
                }
                else
                {
                    Console.WriteLine("Error You Entered Invalid Score Id Value");
                    goto enterscoreid;
                }
            }
            else
            {

                Console.WriteLine("Error Invalid Score Id Value");
                goto enterscoreid;
            }
        enterstudentid:
            Console.WriteLine();
            Console.Write("Enter Student Id:  ");
            string input = Console.ReadLine().ToUpper();

            if (int.TryParse(input, out int studentid))
            {
                if (studentid > 0)
                {
                    query = $"update score set studentid = {studentid} where id = {scoreid}";
                    score.UpdataScore(query);
                }
                else
                {
                    Console.WriteLine("Error You Entered Invalid Student Id Value");
                    goto enterstudentid;
                }
            }
            else
            {

                Console.WriteLine("Error Invalid Student Id Value");
                goto enterstudentid;
            }
        }
        static void UpdateScoreCourseId()
        {
        enterscoreid:
            Console.WriteLine();
            Console.Write("Enter ScoreID:  ");
            string input1 = Console.ReadLine().ToUpper();

            if (int.TryParse(input1, out int scoreid))
            {
                if (scoreid > 0)
                {
                    goto entercourseid;
                }
                else
                {
                    Console.WriteLine("Error You Entered Invalid Score Id Value");
                    goto enterscoreid;
                }
            }
            else
            {

                Console.WriteLine("Error Invalid Score Id Value");
                goto enterscoreid;
            }
        entercourseid:
            Console.WriteLine();
            Console.Write("Enter Course Id:  ");
            string input = Console.ReadLine().ToUpper();

            if (int.TryParse(input, out int courseId))
            {
                if (courseId > 0)
                {
                    query = $"update score set courseid = {courseId} where id = {scoreid}";
                    score.UpdataScore(query);
                }
                else
                {
                    Console.WriteLine("Error You Entered Invalid Course Id Value");
                    goto entercourseid;
                }
            }
            else
            {

                Console.WriteLine("Error Invalid Course Id Value");
                     goto entercourseid;
                ;
            }
        }
        static void UpdateScoreGrade()
        {
        enterscoreid:
            Console.WriteLine();
            Console.Write("Enter ScoreID:  ");
            string input1 = Console.ReadLine().ToUpper();

            if (int.TryParse(input1, out int scoreid))
            {
                if (scoreid > 0)
                {
                    goto entercoursegrade;
                }
                else
                {
                    Console.WriteLine("Error You Entered Invalid Score Id Value");
                    goto enterscoreid;
                }
            }
            else
            {

                Console.WriteLine("Error Invalid Score Id Value");
                goto enterscoreid;
            }
        entercoursegrade:
            Console.WriteLine();
            Console.Write("Enter Course Grade:  ");
            string input = Console.ReadLine().ToUpper();

            if (float.TryParse(input, out float courseGrade))
            {
                if (courseGrade > 0)
                {
                    query = $"update score set score = {courseGrade} where id = {scoreid}";
                    score.UpdataScore(query);
                }
                else
                {
                    Console.WriteLine("Error You Entered Invalid Student Id Value");
                    goto entercoursegrade;
                }
            }
            else
            {

                Console.WriteLine("Error Invalid Student Id Value");
                goto entercoursegrade;
            }
        }
        static void DeleteScore()
        {
        enterscoreid:

            Console.WriteLine();
            Console.Write("Enter Score ID:  ");
            string input = Console.ReadLine().ToUpper();

            if (int.TryParse(input, out int id))
            {
                if (id > 0)
                {
                    score.DeleteScore(id);
                }
                else
                {
                    Console.WriteLine("Error Invalid Course Id Value");
                    goto enterscoreid;
                }
            }
            else
            {

                Console.WriteLine("Error Invalid Score Id Value");
                goto enterscoreid;
            }
        }

        static void DisplayScore()
        {
            query = "select score.id,student.studentname,course.coursename,score as grade  from score ";
            query +="inner join student on score.studentid = student.id inner join course on score.courseid = course.id";
            score.DisplayScore(query);
        }
       

        static void DisplayScoreTextFile()
        {

            query = "select score.id,student.studentname,course.coursename,score as grade  from score ";
            query += "inner join student on score.studentid = student.id inner join course on score.courseid = course.id";
            score.DisplayScoreTextFile(query);
        }







    }
}
