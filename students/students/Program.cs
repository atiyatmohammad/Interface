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
using System.Runtime.InteropServices;


namespace students
{
    
    internal class Program
    {
    
        static Student student = new Student();   // instance for student class
       
        static Course course = new Course();      // instance for course class 
        static Score score = new Score();         // instance for score class
                 
        static string query = "";

        public static object Get { get; private set; }

        static void Main(string[] args)
        {
            
            consolecustomlayout();       // method  custom console layout
            
           
            login();

        startprogram:
            Console.Title = "School Project";   // change console title

            Console.Clear();
            Console.WriteLine(" F1: Manage Student   F2:Manage Course   F3:Manage Score    " +
                "                                    F10:Exit Program");
        Keyspart:
            switch (CheckKey())        // excute method in loop until they press F1,F2,F10 
            {
                case "F1":
                    goto studentmenu;  // go to studentmenu

                case "F2":
                    goto coursemenu;   // go to course menu
                    
                case "F3":
                    goto scoremenu;    // go to score menu
                case "F10":
                    return;

                default:
                    goto Keyspart;
            }
        studentmenu:                // start student menue
           
            StudentMenu();          // calling student menu items
            Console.WriteLine();
        studentmenu1:
            string str = "";
            Console.Write($"{str,48}Enter Your Selection: ");
            string input = Console.ReadLine().ToLower();
            if (int.TryParse(input, out int selectOption))
            {
                goto studentmenu2;

            }
            else
            {
                Console.WriteLine("Error Inavlid Value");
                goto studentmenu1;
            }

           studentmenu2:
            switch (selectOption)
            {
                case 1:
                    AddStudent();
                    PressKey();
                    goto studentmenu;
                case 2:
                    DeleteStudent();
                    PressKey();
                    goto studentmenu;
                case 3:
                    UpdateStudentGender();
                    PressKey();
                    goto studentmenu;
                case 4:
                    DisplayStudents();
                    PressKey();
                    goto studentmenu;

                case 5:
                    showstudentcount();
                    PressKey();
                    goto studentmenu;
                case 6:
                    ShowStudentByIdNo();
                    PressKey();
                    goto studentmenu;
                case 7:

                default:
                    if (selectOption == 7)
                    {
                        goto startprogram;
                    }
                    else
                    {
                        goto studentmenu;
                    }
            }
        coursemenu:
            // DisplayMenu();
            CourseMenu();
            Console.WriteLine();
        coursemenu1:
             str = "";
            Console.Write($"{str,48}Enter Your Selection: ");
            input = Console.ReadLine().ToLower();
            if (int.TryParse(input, out int selectOption1))
            {
                goto coursemenu2;

            }
            else
            {
                Console.WriteLine("Error Inavlid Value");
                goto coursemenu1;
            }

        coursemenu2:

            switch (selectOption1)
            {
                case 1:
                    AddCourse();
                    PressKey();
                    goto coursemenu;
                case 2:
                    UpdateCourseName();
                    PressKey();
                    goto coursemenu;
                case 3:
                    DeleteCourse();
                    PressKey();
                    goto coursemenu;
                case 4:
                    DisplayCoursess();
                    goto coursemenu;
                case 5:
                    DisplayCourseTextFile();
                    // PressKey();
                    goto coursemenu;
                case 6:

                default:
                    if (selectOption1 == 6)
                    {
                        goto startprogram;
                    }
                    else
                    {
                        goto coursemenu;
                    }
            }



        scoremenu:
            // DisplayMenu();
            ScoreMenu();
            Console.WriteLine();
        scoremenu1:
             str = "";
            Console.Write($"{str,48}Enter Your Selection: ");
             input = Console.ReadLine().ToLower();
            if (int.TryParse(input, out int selectOption2))
            {
                goto scoremenu2;

            }
            else
            {
                Console.WriteLine("Error Inavlid Value");
                goto scoremenu1;
            }

        scoremenu2:

            switch (selectOption2)
            {
                case 1:
                    AddScore();
                    PressKey();
                    goto scoremenu;
                case 2:
                    UpdateScoreStudentId();
                    PressKey();
                    goto scoremenu;
                case 3:
                    UpdateScoreCourseId();
                    PressKey();
                    goto scoremenu;
                case 4:
                    UpdateScoreGrade();
                    PressKey();
                    goto scoremenu;
                case 5:
                    DeleteScore();
                    PressKey();
                    goto scoremenu;
                case 6:
                    DisplayScore();
                    goto scoremenu;
                case 7:
                    DisplayScoreTextFile();
                    // PressKey();
                    goto scoremenu;
                case 8:

                default:
                    if (selectOption2 == 8)
                    {
                        goto startprogram;
                    }
                    else
                    {
                        goto scoremenu;
                    }
            }

        }
        

        static void consolecustomlayout()    // console custom change color,font size , set window size
        {
            ChangeFontSize changeFontSize = new ChangeFontSize(); // instanc of class ChangeFontSize
            
            Console.BackgroundColor = ConsoleColor.Cyan;      // change background color
            Console.ForegroundColor = ConsoleColor.Black;    
           // Console.SetWindowSize(116, 60); // set the window size to 116 column and 30 rows
            Console.CursorSize = 10;
            Thread.Sleep(1000);

            changeFontSize.changefont(); // calling class that change font size
            
            
            
            //Console.SetWindowPosition(32, 32);
           
        }
        static bool login()  // return true when he login successfully
        {
        start:
            Console.Clear();
            Console.WriteLine();
            string str = "";
            Console.Write($"{str,44}Enter User Name:  ");
            string userName = Console.ReadLine();

            if (userName.Length  < 5)
            {
                Console.WriteLine("Error Invalid UserName Length", -10);
                goto start;
            }
        part2:
            Console.WriteLine();
            Console.Write($"{str,44}Enter  Password:  ");
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
        
        static void StudentMenu()
        {
            Console.Title = "Manage Students";
            Console.Clear();
           // Console.WriteLine("Manage Student");
            Console.WriteLine();
            string str = " ";
            
            Console.WriteLine($"{str,-44}  1    AddStudent");
            Console.WriteLine($"{str,-44}  2    DeleteStudent");
            Console.WriteLine($"{str,-44}  3    UpdateStudent");
            Console.WriteLine($"{str,-44}  4    Display Student List");
            Console.WriteLine($"{str,-44}  5    StudentsCount");
            Console.WriteLine($"{str,-44}  6    Search Student By Id");
            Console.WriteLine($"{str,-44}  7    Exit Manage Students ");
        }
        static void CourseMenu()
        {
            Console.Title = "Manage Courses";
            Console.Clear();
           // Console.WriteLine("Manage Course");
            Console.WriteLine();
            string str = " ";
            
            Console.WriteLine($" {str,-44} 1  Add Course");
            Console.WriteLine($"{str,-44}  2  Update Course");
            Console.WriteLine($"{str,-44}  3  Delete Course");
            Console.WriteLine($"{str,-44}  4  Display Courses");
            Console.WriteLine($"{str,-44}  5  Display Courses Text File");
            Console.WriteLine($"{str,-44}  6  Exit Manage Courses");

        }
        static void ScoreMenu()
        {
            Console.Title = "SManage Students Grades";
            Console.Clear();
           // Console.WriteLine("Manage Students Grades");
            Console.WriteLine();
            string str = "";
            Console.WriteLine($"{str,-44}  1   Add Student Score");
            Console.WriteLine($"{str,-44}  2   Update Score StudentId");
            Console.WriteLine($"{str,-44}  3   Update Score CourseId");
            Console.WriteLine($"{str,-44}  4   Update Score Grade");
            Console.WriteLine($"{str,-44}  5   Delete Student Score");
            Console.WriteLine($"{str,-44}  6   Display Student Scores");
            Console.WriteLine($"{str,-44}  7   Display Student Score Text File");
            Console.WriteLine($"{str,-44}  8   Exit Manage Students Scores");
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
            student.AddStudent( name, gender); 


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
                    student.deleteStudent(id);
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
                    student.UpdateStudent(id, name, gender);
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
            student.ShowStudents(query);

        }
        static void DisplayStudents()
        {
            {
                query = "select *  from student";
                student.ShowStudents(query);
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
                    student.ShowStudents(query);
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
            while (Console.ReadKey().Key != ConsoleKey.Enter ) { }
        }
        static string CheckKey()
        {
            ConsoleKeyInfo keyInfo;
            starthere:
            
                keyInfo = Console.ReadKey();
                string key1 = "";
               // Console.WriteLine("you entered: " + keyInfo.KeyChar);
               if (keyInfo.Key == ConsoleKey.F1 )
                {
                    key1 = "F1";
                    return key1;
                }
                if (keyInfo.Key == ConsoleKey.F2)
                {
                    key1 = "F2";
                    return key1;
                }
                if (keyInfo.Key == ConsoleKey.F3)
                {
                    key1 = "F3";
                    return key1;
                }
            if (keyInfo.Key == ConsoleKey.F10)
            {
                key1 = "F10";
                return key1;
            }
            goto starthere;
            
            
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
