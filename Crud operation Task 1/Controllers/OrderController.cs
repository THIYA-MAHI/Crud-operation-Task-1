using Crud_operation_Task_1.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crud_operation_Task_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }
    }
}
