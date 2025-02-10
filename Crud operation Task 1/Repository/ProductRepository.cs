using Crud_operation_Task_1.Database;
using Crud_operation_Task_1.Entity;
using Crud_operation_Task_1.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Crud_operation_Task_1.Repository
{
    public class ProductRepository:IProductRepository
    {
        private readonly appDbContext _context;

        public ProductRepository(appDbContext context)
        {
            _context = context;
        }
        public async Task<List<Product>> GetAllProducts()
        {
            return await _context.Product.ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _context.Product.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddProduct(Product product)
        {
            await _context.Product.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProduct(Product product)
        {
            _context.Product.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(int id)
        {
            var product = await GetProductById(id);
            if (product != null)
            {
                _context.Product.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

    }
}
