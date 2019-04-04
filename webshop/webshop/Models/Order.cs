using System;
using System.Collections.Generic;

namespace webshop.Models
{
    public class Order
    {
        public Customer customer { get; set; }
        public List<OrderItems> orderItems { get; set; }
    }
}
