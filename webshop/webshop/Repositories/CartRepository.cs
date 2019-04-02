using System.Collections.Generic;
using System.Linq;
using Dapper;
using MySql.Data.MySqlClient;
using webshop.Models;

namespace webshop.Repositories
{
    public class CartRepository
    {
        private readonly string connectionString;

        public CartRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Cart> Get(string guid)
        {
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            {
                //return connection.Query<Cart>("SELECT * FROM cartItems WHERE cart_guid = @guid", new { guid }).ToList();
                 return connection.Query<Cart>("SELECT cartItems.id, cartItems.product_id, cart_guid, product_name, product_image, product_brand, product_price FROM cartItems LEFT JOIN shoes ON cartItems.product_id = shoes.product_Id WHERE cart_guid = @guid", new { guid }).ToList();
            }
        }
    }
}
