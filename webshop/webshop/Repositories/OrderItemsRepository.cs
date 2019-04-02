using System;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;
using webshop.Models;

namespace webshop.Repositories
{
    public class OrderItemsRepository
    {
        private readonly string connectionString;

        public OrderItemsRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<OrderItems> Get(string guid)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                return connection.Query<OrderItems>("cart_guid, product_id, product_name, product_price, SUM(product_price) AS Price FROM cartItems LEFT JOIN products ON cartItems.product_id = products.id WHERE cart_guid = @guid GROUP BY product_id", new { guid }).ToList();
            }
        }
    }
}
