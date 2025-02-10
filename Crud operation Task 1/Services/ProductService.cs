using Crud_operation_Task_1.Entity;
using Crud_operation_Task_1.IRepository;
using Crud_operation_Task_1.IService;
using Crud_operation_Task_1.Models.Request_model;
using Crud_operation_Task_1.Models.Response_Model;

namespace Crud_operation_Task_1.Services
{
    public class ProductService:IProductService
    {

        private readonly IProductRepository   _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProductResponse>> GetProducts()
        {
            var products = await _repository.GetAllProducts();
            return products.Select(p => new ProductResponse
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Stock = p.Stock,
                Category = p.Category,
                CreatedAt = p.CreatedAt
            }).ToList();
        }

        public async Task<ProductResponse> GetProductById(int id)
        {
            var product = await _repository.GetProductById(id);
            if (product == null) return null;

            return new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                Category = product.Category,
                CreatedAt = product.CreatedAt
            };
        }

        public async Task AddProduct(ProductRequest request)
        {
            var product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Stock = request.Stock,
                Category = request.Category
            };

            await _repository.AddProduct(product);
        }

        public async Task UpdateProduct(int id, ProductRequest request)
        {
            var product = await _repository.GetProductById(id);
            if (product == null) return;

            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;
            product.Stock = request.Stock;
            product.Category = request.Category;

            await _repository.UpdateProduct(product);
        }

        public async Task DeleteProduct(int id)
        {
            await _repository.DeleteProduct(id);
        }
    }
}
