using E_Commerce_2.Context;
using E_Commerce_2.Entities;
using E_Commerce_2.Interfaces.Repositories;

namespace E_Commerce_2.Implementations.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly E_commerceContext _e_CommerceContext;

        public CartRepository(E_commerceContext e_CommerceContext)
        {
            _e_CommerceContext = e_CommerceContext;
        }
        public void AddCart(Cart cart)
        {
            _e_CommerceContext.Add(cart);
            _e_CommerceContext.SaveChanges();
        }
        public Cart GetCartById(int id)
        {
            var cart = _e_CommerceContext.Carts.SingleOrDefault(x => x.Id == id);
            return cart;
        }
        public void RemoveCart(int id)
        {
            var cart = _e_CommerceContext.Carts.SingleOrDefault(x => x.Id == id);
            _e_CommerceContext.Remove(cart);
            _e_CommerceContext.SaveChanges();
        }
    }
}
