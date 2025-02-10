
using Crud_operation_Task_1.Database;
using Crud_operation_Task_1.IRepository;
using Crud_operation_Task_1.IService;
using Crud_operation_Task_1.Repository;
using Crud_operation_Task_1.Services;
using Microsoft.EntityFrameworkCore;

namespace Crud_operation_Task_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<appDbContext>(opt =>
            opt.UseSqlServer(builder.Configuration.GetConnectionString("orderManagementSystem")));

            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IProductService, ProductService>();

            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IOrderService, OrderService>();

            var app = builder.Build();
            

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
