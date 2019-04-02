using System;
namespace webshop.Models
{
    public class Cart
    {
        public int id { get; set; }
        public int product_id { get; set; }
        public string cart_guid { get; set; }
        public string product_name { get; set; }
        public string product_image { get; set; }
        public string product_brand { get; set; }
        public int product_price { get; set; }
    }
}
