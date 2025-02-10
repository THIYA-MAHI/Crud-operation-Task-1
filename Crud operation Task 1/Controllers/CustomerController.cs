using Crud_operation_Task_1.IService;
using Crud_operation_Task_1.Models.Request_model;
using Crud_operation_Task_1.Models.Respones_Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crud_operation_Task_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }


            /// Get all customers
            [HttpGet]
            public async Task<ActionResult<List<CutomerResponse>>> GetAllCustomers()
            {
                var customers = await _service.GetCustomers();
                return Ok(customers);
            }

            /// Get customer by ID
            [HttpGet("{id}")]
            public async Task<ActionResult<CutomerResponse>> GetCustomerById(int id)
            {
                var customer = await _service.GetCustomerById(id);
                if (customer == null) return NotFound();
                return Ok(customer);
            }

            /// Add a new customer
            [HttpPost]
            public async Task<ActionResult<CutomerResponse>> AddCustomer([FromBody] CutomerRequest customer)
            {
                if (customer == null) return BadRequest("Invalid data.");

                await _service.AddCustomer(customer);
                return CreatedAtAction(nameof(GetCustomerById), new { id = customer.Email }, customer);
            }

            /// Update an existing customer
            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateCustomer(int id, [FromBody] CutomerRequest customer)
            {
                if (customer == null) return BadRequest("Invalid data.");

                await _service.UpdateCustomer(id, customer);
                return NoContent();
            }

            /// Delete a customer by ID
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteCustomer(int id)
            {
                await _service.DeleteCustomer(id);
                return NoContent();
            }
        }
    }
