using webshop.Models;
using webshop.Repositories;

namespace webshop.Services
{
    public class CheckoutService
    {
        private readonly CustomerRepository customerRepository;
        private readonly OrderItemsRepository orderItemsRepository;

        public CheckoutService(CustomerRepository customerRepository, OrderItemsRepository orderItemsRepository)
        {
            this.customerRepository = customerRepository;
            this.orderItemsRepository = orderItemsRepository;
        }

        public Order Get(string guid)
        {
            var customer = this.customerRepository.Get(guid);
            var orderItems = this.orderItemsRepository.Get(guid);

            return new Order
            {
                customer = customer,
                orderItems = orderItems
            };
        }

    }
}
