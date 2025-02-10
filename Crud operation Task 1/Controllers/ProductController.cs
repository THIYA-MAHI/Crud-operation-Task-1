using Crud_operation_Task_1.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crud_operation_Task_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }
    }
}
