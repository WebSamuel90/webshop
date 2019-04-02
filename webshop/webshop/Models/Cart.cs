using System;
namespace webshop.Models
{
    public class Cart
    {
        public int id { get; set; }
        public int product_id { get; set; }
        public int cart_guid { get; set; }
        public int product_name { get; set; }
        public int product_image { get; set; }
        public int product_brand { get; set; }
        public int product_price { get; set; }
    }
}
