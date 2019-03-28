using System;
using System.Collections.Generic;
using webshop.Modals;
using webshop.Repositories;

namespace webshop.Services
{
    public class ProductsService
    {
        private readonly IProductsRepository productsRepository;

        public ProductsService(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public List<Product> Get()
        {
            return this.productsRepository.Get();
        }

        public Product Get(int id)
        {
            return this.productsRepository.Get(id);
        }

        public void Add(Product product)
        {
            this.productsRepository.Add(product);
        }
    }
}