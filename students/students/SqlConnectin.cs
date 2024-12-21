using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace students
{
    internal class SqlConnectin
    {
       // public  string datasource = "WWN15I5-8BK1T\SQLEXPRESS"; // your server
       // private readonly string database = "school";

       // public string connstring = @"Server=WWN15I5-8BK1T\"+"SQLEXPRESS;Database=school;Trusted_Connection=True;";
       // readonly string connstring = "Server=" + datasource+ ";Database="+database+;Trusted_Connection=True;";
        //readonly SqlConnection conn = new SqlConnection(connstring);
        static void con() 
        {
            string connstring = @"Server=WWN15I5-8BK1T\" + "SQLEXPRESS;Database=school;Trusted_Connection=True;";
            SqlConnection conn = new SqlConnection(connstring);
        }
        
    }
}
