using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using MySql.Data.MySqlClient;
using webshop.Models;

namespace webshop.Repositories
{
    public class CustomerRepository
    {
        private readonly string connectionString;

        public CustomerRepository(string connectionstring)
        {
            this.connectionString = connectionstring;
        }

        public List<Customer> Get()
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                return connection.Query<Customer>("SELECT * FROM customer").ToList();
            }
        }

        public Customer Get(string guid)
        {
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            {
                return connection.QuerySingleOrDefault<Customer>("SELECT name_customer, adress_customer, cart_guid FROM customer WHERE cart_guid = @guid", new { guid });
            }
        }

        public void Add(Customer customer)
        {
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            {
                connection.Execute("INSERT INTO customer (name_customer, adress_customer, cart_guid) VALUES (@name_customer, @adress_customer, @cart_guid)", customer);
            }
        }
    }
}
