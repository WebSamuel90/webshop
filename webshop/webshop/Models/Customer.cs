using System;
namespace webshop.Models
{
    public class Customer
    {
        public int id { get; set; }
        public string name_customer { get; set; }
        public string adress_customer { get; set; }
        public string cart_guid { get; set; }
    }
}
