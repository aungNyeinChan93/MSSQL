using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Tuto_01.Features
{
    public class Order
    {

        private readonly string _databaseStr = "Data Source=.;Initial Catalog=MyDatabase;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;";

        private SqlConnection _connection;

        public Order( )
        {
            _connection = new SqlConnection(_databaseStr);
        }

        public void GetAllOrders()
        {
            DataTable table = new DataTable("Orders");
            _connection.Open();
            string query = @"SELECT [order_id]
                              ,[customer_id]
                              ,[order_date]
                              ,[sales]
                          FROM [dbo].[orders]";
            SqlCommand cmd = new SqlCommand(query, _connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                Console.WriteLine($"Sale amount is {row["sales"]} \r\n");
            }
            _connection.Close();
        }
    }
}
