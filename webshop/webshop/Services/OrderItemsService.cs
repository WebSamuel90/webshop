using System;
using System.Collections.Generic;
using webshop.Models;
using webshop.Repositories;

namespace webshop.Services
{
    public class OrderItemsService
    {
        private readonly OrderItemsRepository orderItemsRepository;

        public OrderItemsService(OrderItemsRepository orderItemsRepository)
        {
            this.orderItemsRepository = orderItemsRepository;
        }

        public List<OrderItems> Get(string guid)
        {
            return this.orderItemsRepository.Get(guid);
        }
    }
}
