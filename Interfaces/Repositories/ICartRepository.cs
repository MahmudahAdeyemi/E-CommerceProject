using E_Commerce_2.Entities;

namespace E_Commerce_2.Interfaces.Repositories
{
    public interface ICartRepository
    {
        void AddCart(Cart cart);
        Cart GetCartById(int id);
        void RemoveCart(int id);
    }
}