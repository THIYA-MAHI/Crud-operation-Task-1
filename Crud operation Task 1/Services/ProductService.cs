using Crud_operation_Task_1.IRepository;
using Crud_operation_Task_1.IService;

namespace Crud_operation_Task_1.Services
{
    public class ProductService:IProductService
    {

        private readonly IProductRepository   _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }
    }
}
