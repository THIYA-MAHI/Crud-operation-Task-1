using Crud_operation_Task_1.Models.Request_model;
using Crud_operation_Task_1.Models.Response_Model;

namespace Crud_operation_Task_1.IService
{
    public interface IProductService
    {
        Task<List<ProductResponse>> GetProducts();
        Task<ProductResponse> GetProductById(int id);
        Task AddProduct(ProductRequest request);
        Task UpdateProduct(int id, ProductRequest request);
        Task DeleteProduct(int id);
    }
}
