using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace AzureSQL2
{
    class Program
    {
        static void Main(string[] args)
        {
            string ConnStr = "your connection string";

            // protects aganinst sql injection
            /*using (var conn = new SqlConnection(ConnStr))
            {
                using (var command = conn.CreateCommand())
                {
                    
                    command.CommandText = @"CREATE TABLE MYTABLE(NAME TEXT, AGE INTEGER, SCHOOL TEXT)";
                    // OPEN THE CONNECTION
                    conn.Open(); 
                    // read data 
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine();

                        }
                    }
                    
                }
            }*/
            Console.WriteLine("Executing Command.....");
            using (var conn = new SqlConnection(ConnStr))
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText="INSERT INTO MYTABLE(NAME,AGE,SCHOOL) VALUES(@NAME, @AGE,@SCHOOL)";
                    cmd.Parameters.AddWithValue("@NAME","PABLO VERAMENDI");
                    cmd.Parameters.AddWithValue("@AGE", 51);
                    cmd.Parameters.AddWithValue("@SCHOOL", "MICROSOFT");

                    // open the sql database
                    conn.Open();
                    cmd.ExecuteScalar();
                    conn.Close();
                    /*int insertedId = (int)cmd.ExecuteScalar();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine();

                        }
                    }*/
                }
                
            }
            Console.WriteLine("command executed......");
            Console.ReadKey();
        }
    }
}
