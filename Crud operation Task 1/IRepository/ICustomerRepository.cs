using Crud_operation_Task_1.Entity;

namespace Crud_operation_Task_1.IRepository
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllCustomers();
        Task<Customer> GetCustomerById(int id);
        Task AddCustomer(Customer customer);
        Task UpdateCustomer(Customer customer);
        Task DeleteCustomer(int id);
    }
}
