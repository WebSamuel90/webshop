using System;
using System.Collections.Generic;
using webshop.Models;
using webshop.Repositories;

namespace webshop.Services
{
    public class CustomerService
    {
        private readonly CustomerRepository customerRepository;

        public CustomerService(CustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public List<Customer> Get()
        {
            return this.customerRepository.Get();
        }

        public Customer Get(string guid)
        {
            return this.customerRepository.Get(guid);
        }

        public bool Add(Customer customer)
        {
            if (customer != null)
            {
                this.customerRepository.Add(customer);
                return true;
            }

            return false;
        }
    }
}
