using System;
using System.Collections.Generic;
using System.Linq;
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
                return connection.Query<OrderItems>("SELECT cart_guid, cartItems.product_id, product_name, product_price, SUM(product_price) AS total_price FROM cartItems LEFT JOIN shoes ON cartItems.product_id = shoes.product_Id WHERE cart_guid = @guid GROUP BY cartItems.product_id", new { guid }).ToList();
            }
        }
    }
}
