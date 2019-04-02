using System;
namespace webshop.Models
{
    public class OrderItems
    {
        public string cart_guid { get; set; }
        public int product_id { get; set; }
        public string product_name { get; set; }
        public int product_price { get; set; }
    }
}
