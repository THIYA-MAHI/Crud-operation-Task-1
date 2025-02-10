using System;
using Crud_operation_Task_1.Database;
using Crud_operation_Task_1.Entity;
using Crud_operation_Task_1.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Crud_operation_Task_1.Repository
{
    public class CustomerRepository:ICustomerRepository
    {
        private readonly appDbContext _context;

        public CustomerRepository(appDbContext context)
        {
            _context = context;
        }

            public async Task<List<Customer>> GetAllCustomers()
            {
                return await _context.customer.ToListAsync();
            }

            public async Task<Customer> GetCustomerById(int id)
            {
                return await _context.customer.FindAsync(id);
            }

            public async Task AddCustomer(Customer customer)
            {
                await _context.customer.AddAsync(customer);
                await _context.SaveChangesAsync();
            }

            public async Task UpdateCustomer(Customer customer)
            {
                _context.customer.Update(customer);
                await _context.SaveChangesAsync();
            }

            public async Task DeleteCustomer(int id)
            {
                var customer = await GetCustomerById(id);
                if (customer != null)
                {
                    _context.customer.Remove(customer);
                    await _context.SaveChangesAsync();
                }
            }
        }
    }

