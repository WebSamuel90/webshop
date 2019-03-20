using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using MySql.Data.MySqlClient;
using webshop.Modals;

namespace webshop.Repositories
{
    public class ProductsRepository
    {
        private readonly string connectionString;

        public ProductsRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Products> Get()
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                return connection.Query<Products>("SELECT * FROM shoes").ToList();

            }
        }
    }
}



