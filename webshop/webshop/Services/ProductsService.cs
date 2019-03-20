using System;
using System.Collections.Generic;
using webshop.Modals;
using webshop.Repositories;

namespace webshop.Services
{
    public class ProductsService
    {
        private readonly ProductsRepository productsRepository;

        public ProductsService(ProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public List<Products> Get()
        {
            return this.productsRepository.Get();
        }
    }
}