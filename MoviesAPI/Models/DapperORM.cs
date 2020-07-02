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
        private static string connectionString = @"Data Source=localhost,1433;Initial Catalog=MoviesDB;User ID=sa;Password=dyw@cthyg@22;"; //can we change this to builder? do we need to?

        public static void ExecuteWithoutReturn(string procedureName, DynamicParameters param)
        {
            using (SqlConnection con = new SqlConnection(connectionString)) // new instance of the connection string
            {
                con.Open(); // open it
                con.Execute(procedureName, param, commandType: CommandType.StoredProcedure); // once opened excecute the store procedure
            }
        }

        public static T ExecuteReturnScalar<T>(string procedureName, DynamicParameters param) // what is return scalar?
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                return con.ExecuteScalar<T>(procedureName, param, commandType: CommandType.StoredProcedure); 
            }
        }


        public static IEnumerable<T> ReturnList<T> (string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                return con.Query<T>(procedureName, param, commandType: CommandType.StoredProcedure); // excecutes a query, returnes the data types as T
            }
        }


    }
}
