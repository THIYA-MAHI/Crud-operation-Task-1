using Crud_operation_Task_1.Entity;
using Crud_operation_Task_1.IRepository;
using Crud_operation_Task_1.IService;
using Crud_operation_Task_1.Models.Request_model;
using Crud_operation_Task_1.Models.Respones_Model;

namespace Crud_operation_Task_1.Services
{
    public class CustomerService:ICustomerService
    {

        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CutomerResponse>> GetCustomers()
        {
            var customers = await _repository.GetAllCustomers();
            return customers.Select(c => new CutomerResponse
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                Phone = c.Phone,
                Address = c.Address,
                CreatedAt = c.CreatedAt
            }).ToList();
        }

        public async Task<CutomerResponse> GetCustomerById(int id)
        {
            var customer = await _repository.GetCustomerById(id);
            if (customer == null) return null;

            return new CutomerResponse
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                Phone = customer.Phone,
                Address = customer.Address,
                CreatedAt = customer.CreatedAt
            };
        }

        public async Task AddCustomer(CutomerRequest request)
        {
            var customer = new Customer
            {
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone,
                Address = request.Address
            };
            await _repository.AddCustomer(customer);
        }

        public async Task UpdateCustomer(int id, CutomerRequest request)
        {
            var customer = await _repository.GetCustomerById(id);
            if (customer == null) return;

            customer.Name = request.Name;
            customer.Email = request.Email;
            customer.Phone = request.Phone;
            customer.Address = request.Address;

            await _repository.UpdateCustomer(customer);
        }

        public async Task DeleteCustomer(int id)
        {
            await _repository.DeleteCustomer(id);
        }
    }
}
