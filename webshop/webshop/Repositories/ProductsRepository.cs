using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using MySql.Data.MySqlClient;
using webshop.Models;

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
                return connection.QuerySingleOrDefault<Product>("SELECT * FROM shoes WHERE product_Id = @id", new { id });

            }
        }

        public void Add(Product product)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                connection.Execute("INSERT INTO shoes (product_Id, product_name, product_image, product_brand, product_price) VALUES(@product_id, @product_name, @product_image, @product_brand, @product_price)", product);
            }
        }
    }
}



