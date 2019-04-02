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

        public CartRepository(string connectionstring)
        {
            this.connectionString = connectionstring;
        }

        public List<Cart> Get(string guid)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                return connection.Query<Cart>("SELECT cartItems.id, product_id, cart_guid, product_name, product_image, product_brand, product_price FROM cartItems LEFT JOIN shoes ON cartItems.product_id = products.id WHERE cart_guid = @guid", new { guid }).ToList();
            }
        }
    }
}
