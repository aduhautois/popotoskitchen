using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using BusinessObjects;
using DataAccess;
using System.Data;
using System.Data.SqlClient;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var conn = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=popotokitchen;Integrated Security=True");
            var query = @"sp_complete_order_lines";
            SqlCommand cmd = new SqlCommand(query, conn);

            int count = 0;
            int orderID = 0;

            cmd.Parameters.AddWithValue("@Completed", 1);
            cmd.Parameters.AddWithValue("@RecipeID", "Black Truffle Risotto");

            try
            {
                conn.Open();
                count = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            Console.WriteLine(count);

            Console.ReadKey();
        }
    }
}
