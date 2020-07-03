using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace MoviesAPI.Models
{
    public static class DapperORM
    {

        private static string connectionString = @"Data Source=localhost,1433;Initial Catalog=MoviesDB;User ID=sa;Password=<pass123word;"; //can we change this to builder? do we need to? dyw@cthyg@22 <YourStrong@Passw0rd>


        public static void ExecuteWithoutReturn(string procedureName, DynamicParameters param)
        {
            //try
            //{
                using (SqlConnection con = new SqlConnection(connectionString)) // new instance of the connection string
                {
                    con.Open(); // open it
                    Console.WriteLine("Connection opened, request sent"); // console logging 
                    con.Execute(procedureName, param, commandType: CommandType.StoredProcedure); // once opened excecute the store procedure
                    
                }
            //}
            //catch (SqlException error)
            //{
            //    Console.WriteLine(error.ToString());
            //    Console.WriteLine("testing");// errors dont come back as strings so we are just conveting it to sring.
            //}
        }

        public static T ExecuteReturnScalar<T>(string procedureName, DynamicParameters param) // what is return scalar?
        {
            using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    Console.WriteLine("Connection opened, request sent"); // console logging 
                    return con.ExecuteScalar<T>(procedureName, param, commandType: CommandType.StoredProcedure);
                }
        }
         

        public static IEnumerable<T> ReturnList<T> (string procedureName, DynamicParameters param = null)
        {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    Console.WriteLine("Connection opened, request sent"); // console logging 
                    return con.Query<T>(procedureName, param, commandType: CommandType.StoredProcedure); // excecutes a query, returnes the data types as T
                }
        }
    }
}
