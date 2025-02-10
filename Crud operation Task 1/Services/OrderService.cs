using Crud_operation_Task_1.IRepository;
using Crud_operation_Task_1.IService;

namespace Crud_operation_Task_1.Services
{
    public class OrderService:IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

    }
}
