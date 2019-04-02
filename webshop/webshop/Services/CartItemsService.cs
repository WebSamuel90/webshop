using System.Collections.Generic;
using webshop.Models;
using webshop.Repositories;

namespace webshop.Services
{
    public class CartItemsService
    {
        private readonly CartItemsRepository cartItemsRepository;

        public CartItemsService(CartItemsRepository cartItemsRepository)
        {
            this.cartItemsRepository = cartItemsRepository;
        }

        public List<CartItems> Get()
        {
            return cartItemsRepository.Get();
        }

        public bool Add(CartItems cartItem)
        {
            this.cartItemsRepository.Add(cartItem);
            return true;
        }

        public List<CartItems> Get(string guid)
        {
            return this.cartItemsRepository.Get(guid);
        }
    }
}
