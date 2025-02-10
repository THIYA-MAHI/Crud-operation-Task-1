using Crud_operation_Task_1.Models.Request_model;
using Crud_operation_Task_1.Models.Respones_Model;

namespace Crud_operation_Task_1.IService
{
    public interface ICustomerService
    {
        Task<List<CutomerResponse>> GetCustomers();
        Task<CutomerResponse> GetCustomerById(int id);
        Task AddCustomer(CutomerRequest customer);
        Task UpdateCustomer(int id, CutomerRequest customer);
        Task DeleteCustomer(int id);
    }
}
