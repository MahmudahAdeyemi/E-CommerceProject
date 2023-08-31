using E_Commerce_2.Context;
using E_Commerce_2.Entities;
using E_Commerce_2.Interfaces.Repositories;

namespace E_Commerce_2.Implementations.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly E_commerceContext _e_commerceContext;

        public ProductRepository(E_commerceContext e_commerceContext)
        {
            _e_commerceContext = e_commerceContext;
        }
        public void AddProduct(Product product)
        {
            _e_commerceContext.Add(product);
            _e_commerceContext.SaveChanges();
        }
        public void UpdateProduct(Product product)
        {
            _e_commerceContext.Update(product);
            _e_commerceContext.SaveChanges();
        }
        public Product GetProductById(int id)
        {
            var product = _e_commerceContext.Products.Single(x => x.Id == id);
            return product;
        }
        public List<Product> GetAllProduct()
        {
            var products = _e_commerceContext.Products.ToList();
            return products;
        }
    }
}
