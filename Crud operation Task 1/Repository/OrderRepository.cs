using Crud_operation_Task_1.Database;
using Crud_operation_Task_1.IRepository;

namespace Crud_operation_Task_1.Repository
{
    public class OrderRepository:IOrderRepository
    {

        private readonly appDbContext _context;

        public OrderRepository(appDbContext context)
        {
            _context = context;
        }
    }
}
