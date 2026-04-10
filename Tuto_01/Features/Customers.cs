using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Tuto_01.Models;

namespace Tuto_01.Features
{
    public class Customers
    {
        private readonly string _databaseStr = "Data Source=.;Initial Catalog=MyDatabase;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;";

        private SqlConnection _connetion;

        public Customers()
        {
            _connetion = new SqlConnection(this._databaseStr);
        }

        public void GetAll()
        {
            using (IDbConnection _db = _connetion)
            {
                _db.Open();
                var customers = _db.Query<CustomerModel>("select * from customers").ToList();
                if(customers is null) return ;
                foreach (var customer in customers)
                {
                    Console.WriteLine($"Customer Name  = {customer?.first_name}");
                }

                _db.Close();
            }

        }

        public void Create(string name,string country,int score)
        {
            using (IDbConnection _db = _connetion)
            {
                _db.Open();
                var maxId = _db.Query<CustomerModel>("select * from customers").ToList().Max(c=>c.id);

                string query = @"INSERT INTO [dbo].[customers]
                                   ([id]
                                   ,[first_name]
                                   ,[country]
                                   ,[score])
                             VALUES
                                   (@Id
                                   ,@FirstName
                                   ,@Country
                                   ,@Score)";

                var res = _db.Execute(query, new { Id = maxId + 1, FirstName = name, Country = country, Score = score });
                Console.WriteLine(res >= 1 ? "Create success" : "Create Fail");
                _db.Close();
            }
        }
    }
}
