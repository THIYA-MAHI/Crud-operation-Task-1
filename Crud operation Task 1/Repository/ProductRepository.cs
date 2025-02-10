using Crud_operation_Task_1.Database;
using Crud_operation_Task_1.IRepository;

namespace Crud_operation_Task_1.Repository
{
    public class ProductRepository:IProductRepository
    {
        private readonly appDbContext _context;

        public ProductRepository(appDbContext context)
        {
            _context = context;
        }
    }
}
