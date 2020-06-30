using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;// need to add this dependancy by right clicking in dependencies and search for it and add it.

namespace MoviesAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

//namespace SQLtemplate
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            try // this is creating a string for our connection
//            {
//                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
//                builder.DataSource = "localhost,1433"; // localhost, docker port
//                builder.UserID = "sa"; // sql username
//                builder.Password = "<YourStrong@Passw0rd>"; // sql password
//                builder.InitialCatalog = "MoviesDB"; //database name we want to connect to

//                //the string we are building is “DataSource=localhost,1433;UserID=sa;Password=<YourStrong@Passw0rd>;Initial Catalog=Movies;”
//                // so all we are doing is giving it the values and it is creating the sring, without the builder it would look like the above
//                // writing the console.writeline BEFORE the connection is attempted..

//                // what would you like to send to SQL? so we will use a string for the 4 things.

//                string SELECT = "SELECT * FROM Movie"; // just creating shortcut for SELECT. MovieModel is the table inside of Movies database
//                //string INSERT = 
//                //string DELETE;


//                Console.WriteLine("Connecting to SQL server, lets see if it works");
//                //sqlConnection is a class, so we need to create a new instance of it, so connection is our new instance
//                SqlConnection connection = new SqlConnection(builder.ConnectionString); // we pass thru a parameter of builder.ConnectionString, now being combined to use in the string
//                using (connection)
//                {
//                    SqlCommand cmd = new SqlCommand(SELECT, connection); // using SELECT which we created above. eg RUN TO THE SHOP, usemycar to do so
//                    connection.Open(); // opening the connection
//                    using (SqlDataReader reader = cmd.ExecuteReader())
//                    {
//                        while (reader.Read())
//                        {
//                            for (int i = 0; i < reader.FieldCount; i++)
//                            {
//                                Console.WriteLine(reader.GetValue(i));
//                            }
//                        }
//                    }
//                    Console.WriteLine("Done.");
//                }
//            }
//            catch (SqlException error)
//            {
//                Console.WriteLine(error.ToString()); // errors dont come back as strings so we are just conveting it to sring.
//            }
//            Console.Write("All done.");
//            Console.ReadKey();
//        }
//    }
//}

