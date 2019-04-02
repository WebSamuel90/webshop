using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using MySql.Data.MySqlClient;
using webshop.Models;

namespace webshop.Repositories
{
    public class CartItemsRepository
    {
        private readonly string connectionString;

        public CartItemsRepository(string connectionstring)
        {
            this.connectionString = connectionstring;
        }

        public List<CartItems> Get()
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                return connection.Query<CartItems>("SELECT * FROM cartItems").ToList();
            }
        }

        public List<CartItems> Get(string guid)
        {
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            {
                return connection.Query<CartItems>("SELECT cart_guid, COUNT(product_Id) AS items FROM cartItems WHERE cart_guid = @guid", new { guid }).ToList();
            }
        }


        public void Add(CartItems cartItems)
        {
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            {
                connection.Execute("INSERT INTO cartItems (cart_id, product_Id, cart_quantity, cart_guid, product_guid) VALUES (@cart_id, @product_id, @cart_guid, @product_guid)", cartItems);
            }
        }
    }
}
