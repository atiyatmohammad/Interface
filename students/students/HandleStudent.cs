using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace students

{
    
    internal class HandleStudent : IStudent
    {

        
        public void AddStudent( string name, string gender)
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
                Console.WriteLine("Succsessfuly Student Added");
                 


            }
            catch(Exception e)
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
                Console.WriteLine($"{c} Row Deleted Succsessfuly");
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

        public void DisplayStudents(List<Student> ls)
        {
            foreach (Student s in ls)
            {
                Console.WriteLine($"{s.Id} {s.Name} {s.Gender}");
            }
            return;
        }

        public void UpdateStudent(int id,string name, string gender)
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
        public void ShowStudents()
        {
            string connstring = @"Server=WWN15I5-8BK1T\" + "SQLEXPRESS;Database=school1;Trusted_Connection=True;";
            SqlConnection conn = new SqlConnection(connstring);
            string query = $"select * from student";
            
            SqlDataReader dr;
            try
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                dr =  cmd.ExecuteReader();
                StringBuilder result = new StringBuilder();
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    result.Append($"{dr.GetName(i),-18}") ;
                }
                result.AppendLine();
                while (dr.Read())
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        result.Append($"{dr[i],-18}") ;
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
        public void ShowStudentInDataTable() 
        {
            string connstring = @"Server=WWN15I5-8BK1T\" + "SQLEXPRESS;Database=school1;Trusted_Connection=True;";
            SqlConnection conn = new SqlConnection(connstring);
            string query = $"select count(id) as Studentcount from student";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            

            try
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                da.Fill(dt);
                Console.WriteLine("data adaptor");
                StringBuilder stringBuilder = new StringBuilder();
                int i = 0;  
                foreach (DataColumn col in dt.Columns) 
                {
                    if (i==0) stringBuilder.Append($"{col.ColumnName,-6}");
                    else stringBuilder.Append($"{col.ColumnName,-16} ");
                }
                Console.WriteLine(stringBuilder.ToString());   
                foreach (DataRow dr in dt.Rows)
                {
                    Console.WriteLine($"{dr["id"],-6}{dr["studentname"],-15}{dr["gender"],-15}");
                }
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
                    if (i == 0) stringBuilder.Append($"{col.ColumnName,-16}");
                    else stringBuilder.Append($"{col.ColumnName,-16} ");
                }
                //Console.WriteLine(stringBuilder.ToString());
                stringBuilder.AppendLine();
                i = 0;
                foreach (DataRow dr in dt.Rows)
                {
                   // stringBuilder.AppendLine($"{dr["Studentcount"],-16}{dr["MaleStudents"],-16}{dr["MaleStudents"],-16}");
                    stringBuilder.Append($"{dr[i],-16}");
                    i ++;
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

            
        }

        void IStudent.ShowSingleStudent(int id)
        {
            string connstring = @"Server=WWN15I5-8BK1T\" + "SQLEXPRESS;Database=school1;Trusted_Connection=True;";
            SqlConnection conn = new SqlConnection(connstring);
            string query = $"select * from student";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);


            try
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                da.Fill(dt);
                Console.WriteLine("data adaptor");
                StringBuilder stringBuilder = new StringBuilder();
                int i = 0;
                foreach (DataColumn col in dt.Columns)
                {
                    if (i == 0) stringBuilder.Append($"{col.ColumnName,-6}");
                    else stringBuilder.Append($"{col.ColumnName,-16} ");
                }
                Console.WriteLine(stringBuilder.ToString());
                foreach (DataRow dr in dt.Rows)
                {
                    Console.WriteLine($"{dr["id"],-6}{dr["studentname"],-15}{dr["gender"],-15}");
                }
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
    }
}
