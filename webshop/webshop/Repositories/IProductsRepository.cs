using System;
using System.Collections.Generic;
using webshop.Models;

namespace webshop.Repositories
{
    public interface IProductsRepository
    {
        List<Product> Get();
        Product Get(int id);
        void Add(Product product);
    }
}
