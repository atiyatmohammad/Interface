using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace students
{
    internal class Student : IStudent
    {
        public void AddStudent(string name, string gender)
        {
            string connstring = @"Server=WWN15I5-8BK1T\" + "SQLEXPRESS;Database=school1;Trusted_Connection=True;";
            SqlConnection conn = new SqlConnection(connstring);
            string query = $"insert into student(studentname,gender) values ('{name}','{gender}')";
            Console.WriteLine(query);
            try
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Successfully Student Added");



            }
            catch (Exception e)
            {
                Console.WriteLine(" error inserting student " + e.Message);

            }
            finally
            {
                conn.Close();

            }




            return;
            //st.Add(new { id , name, gender });
        }

        public void deleteStudent(int id)
        {
            string connstring = @"Server=WWN15I5-8BK1T\" + "SQLEXPRESS;Database=school1;Trusted_Connection=True;";
            SqlConnection conn = new SqlConnection(connstring);
            string query = $"delete from student where id = {id}";


            try
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                int c = cmd.ExecuteNonQuery();
                Console.WriteLine($"{c} Row Deleted Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(" error reached " + e.Message);

            }
            finally
            {

                conn.Close();

            }
            return;
            //Console.ReadKey();


        }


        public void UpdateStudent(int id, string name, string gender)
        {
            string connstring = @"Server=WWN15I5-8BK1T\" + "SQLEXPRESS;Database=school1;Trusted_Connection=True;";
            SqlConnection conn = new SqlConnection(connstring);
            // update Employee set EmpName = 'moh' where EmpId = 1;
            string query = $"update student set gender = '{gender}' where id = {id}";


            try
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                int c = cmd.ExecuteNonQuery();
                Console.WriteLine($"{c} Row Updated Successfully");
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
        public void ShowStudents(string query)
        {
            string connstring = @"Server=WWN15I5-8BK1T\" + "SQLEXPRESS;Database=school1;Trusted_Connection=True;";
            SqlConnection conn = new SqlConnection(connstring);
            //string query = $"select * from student";

            SqlDataReader dr;
            try
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                dr = cmd.ExecuteReader();
                StringBuilder result = new StringBuilder();
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    result.Append($" {dr.GetName(i),-18}");
                }
                result.AppendLine();
                while (dr.Read())
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        result.Append($" {dr[i],-18}");
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


        public void ShowStudentcount(string query)
        {
            string connstring = @"Server=WWN15I5-8BK1T\" + "SQLEXPRESS;Database=school1;Trusted_Connection=True;";
            SqlConnection conn = new SqlConnection(connstring);
            //string query = $"select * from student";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);



            try
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                da.Fill(dt);
                Console.WriteLine();

                StringBuilder stringBuilder = new StringBuilder();
                int i = 0;
                foreach (DataColumn col in dt.Columns)
                {
                    if (i == 0) stringBuilder.Append($" {col.ColumnName,-16}");
                    else stringBuilder.Append($" {col.ColumnName,-16} ");
                }
                //Console.WriteLine(stringBuilder.ToString());
                stringBuilder.AppendLine();
                i = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    // stringBuilder.AppendLine($"{dr["Studentcount"],-16}{dr["MaleStudents"],-16}{dr["MaleStudents"],-16}");
                    stringBuilder.Append($" {dr[i],-16}");
                    i++;
                    // Console.WriteLine($"{dr["id"],-6}{dr["studentname"],-15}{dr["gender"],-15}");
                }
                Console.WriteLine(stringBuilder.ToString());
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
        public void DisplayMenu() // its not used in the programm
        {
            string str = " ";
            Console.WriteLine("SCHOOL");
            Console.WriteLine($"{str,-25}  AS    AddStudent");
            Console.WriteLine($"{str,-25}  DS    DeleteStudent");
            Console.WriteLine($"{str,-25}  US    UpdateStudent");
            Console.WriteLine($"{str,-25}  DSL   Display Student List");
            Console.WriteLine($"{str,-25}  SC    StudentsCount");
            Console.WriteLine($"{str,-25}  SSS   Search Student By Id");
        }

        ~Student()
        {
            Console.WriteLine("Destructor Executed");
        }
    }
}
