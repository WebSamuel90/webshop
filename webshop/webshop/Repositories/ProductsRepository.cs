using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using MySql.Data.MySqlClient;
using webshop.Modals;

namespace webshop.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly string connectionString;

        public ProductsRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Product> Get()
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                return connection.Query<Product>("SELECT * FROM shoes").ToList();

            }
        }

        public Product Get(int id)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                return connection.QuerySingleOrDefault<Product>("SELECT * FROM shoes WHERE Id = @id", new { id });

            }
        }

        public void Add(Product product)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                connection.Execute("INSERT INTO shoes (id, name, image, brand, price) VALUES(@id, @name, @image, @brand, @price)", product);
            }
        }
    }
}



