using System.Collections.Generic;
using webshop.Models;
using webshop.Repositories;

namespace webshop.Services
{
    public class CartService
    {
        private readonly CartRepository cartRepository;

        public CartService(CartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }

        public List<Cart> Get(string guid)
        {
            return this.cartRepository.Get(guid);
        }
    }
}
