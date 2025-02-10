using Crud_operation_Task_1.Models.Request_model;
using Crud_operation_Task_1.Models.Respones_Model;

namespace Crud_operation_Task_1.IService
{
    public interface IOrderService
    {
        Task<List<OrderResponse>> GetOrders();
        Task<OrderResponse> GetOrderById(int id);
        Task AddOrder(OrderRequest request);
        Task UpdateOrder(int id, OrderRequest request);
        Task DeleteOrder(int id);
    }
}
