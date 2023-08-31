using E_Commerce_2.Entities;

namespace E_Commerce_2.Interfaces.Repositories
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        List<Product> GetAllProduct();
        Product GetProductById(int id);
        void UpdateProduct(Product product);
    }
}