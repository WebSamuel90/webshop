using System;
using System.Collections.Generic;
using webshop.Modals;

namespace webshop.Repositories
{
    public interface IProductsRepository
    {
        List<Product> Get();
        Product Get(int id);
    }
}
