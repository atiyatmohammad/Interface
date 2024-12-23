using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace students
{
    internal class Course : ICourse
    {
        
        public void AddCourse(string courseName)
        {
            string connstring = @"Server=WWN15I5-8BK1T\" + "SQLEXPRESS;Database=school1;Trusted_Connection=True;";
            SqlConnection conn = new SqlConnection(connstring);
            string query = $"insert into course(coursename) values ('{courseName}')";
            Console.WriteLine(query);
            try
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Succsessfuly Course Added");



            }
            catch (Exception e)
            {
                Console.WriteLine(" error in Adding Course " + e.Message);

            }
            finally
            {
                conn.Close();

            }
            return;
        }

        public void DeleteCourse(int id)
        {
            string connstring = @"Server=WWN15I5-8BK1T\" + "SQLEXPRESS;Database=school1;Trusted_Connection=True;";
            SqlConnection conn = new SqlConnection(connstring);
            string query = $"delete from course where id = {id}";


            try
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                int c = cmd.ExecuteNonQuery();
                Console.WriteLine($"{c} Row Deleted Succsessfuly");
            }
            catch (Exception e)
            {
                Console.WriteLine($" error Deleting Course Id {id}" + e.Message);

            }
            finally
            {

                conn.Close();

            }
            return;
        }

        public void DisplayCourses(string query)
        {
            string connstring = @"Server=WWN15I5-8BK1T\" + "SQLEXPRESS;Database=school1;Trusted_Connection=True;";
            SqlConnection conn = new SqlConnection(connstring);
            
            SqlDataReader dr;
            try
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                dr = cmd.ExecuteReader();
                StringBuilder result = new StringBuilder();
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    result.Append($"{dr.GetName(i),-18}");
                }
                result.AppendLine();
                while (dr.Read())
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        result.Append($"{dr[i],-18}");
                    }

                    result.AppendLine();

                }
                Console.WriteLine();
                Console.WriteLine(result);
                dr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(" error reached " + e.Message);

            }
            finally
            {

                conn.Close();

            }

            Console.ReadKey();
        }

        public void DisplayCoursesTextFile(string query)
        {
            string connstring = @"Server=WWN15I5-8BK1T\" + "SQLEXPRESS;Database=school1;Trusted_Connection=True;";
            SqlConnection conn = new SqlConnection(connstring);
            string docPath = string.Empty;
            StringBuilder result = new StringBuilder();
            SqlDataReader dr;
            try
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                dr = cmd.ExecuteReader();
                
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    result.Append($"{dr.GetName(i),-18}");
                }
                result.AppendLine();
                while (dr.Read())
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        result.Append($"{dr[i],-18}");
                    }

                    result.AppendLine();

                }
                Console.WriteLine();
                //Console.WriteLine(result);
                conn.Close();
                dr.Close();
                goto beginwritingtotextfile;
            }
            catch (Exception e)
            {
                Console.WriteLine(" error reached " + e.Message);

            }
            finally
            {

                conn.Close();

            }

            beginwritingtotextfile:
            string fileName = string.Empty;
            docPath =  Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            start:
            Console.WriteLine();
            Console.Write("Enter Name For TextFile: ");
            fileName = Console.ReadLine().ToUpper();

            if (fileName.Length == 0)
            {
                Console.WriteLine("Error Invalid FileName", -18);
                goto start;
            }
            fileName += ".txt";
            fileName = $"{docPath}\\{fileName}";
            FileInfo fileInfo = new FileInfo(fileName);

            if (fileInfo.Exists)
            {
                Console.WriteLine($"{fileName} exist");
                goto endsub;
            }
            else
            {
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, fileName)))
               // {
                //    foreach (string line in result)
                        outputFile.WriteLine(result);
               // }
                Console.WriteLine("done");
               // Console.ReadLine();
            }
         endsub:

            Console.ReadKey();
        }

        public void UpdataCourse(int id, string courseName)
        {
            string connstring = @"Server=WWN15I5-8BK1T\" + "SQLEXPRESS;Database=school1;Trusted_Connection=True;";
            SqlConnection conn = new SqlConnection(connstring);
            // update Employee set EmpName = 'moh' where EmpId = 1;
            string query = $"update course set coursename = '{courseName}' where id = {id}";
            Console.WriteLine(query);
            try
            {


                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                int c = cmd.ExecuteNonQuery();
                Console.WriteLine($"{c} Row Updated Succsessfuly");
            }
            catch (Exception e)
            {
                Console.WriteLine(" Update Error " + e.Message);

            }
            finally
            {

                conn.Close();

            }
            return;
        }
    }
}
