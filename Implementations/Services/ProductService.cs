using E_Commerce_2.Interfaces.Repositories;

namespace E_Commerce_2.Implementations.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
    }
}
