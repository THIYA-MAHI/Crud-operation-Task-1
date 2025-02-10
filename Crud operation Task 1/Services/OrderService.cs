using Crud_operation_Task_1.Entity;
using System;
using Crud_operation_Task_1.IRepository;
using Crud_operation_Task_1.IService;
using Crud_operation_Task_1.Models.Request_model;
using Crud_operation_Task_1.Models.Respones_Model;

namespace Crud_operation_Task_1.Services
{
    public class OrderService:IOrderService
    {
        private readonly IOrderRepository _repository;
        private readonly IProductRepository _productRepository;

        public OrderService(IOrderRepository repository, IProductRepository productRepository)
        {
            _repository = repository;
            _productRepository = productRepository;
        }

        public async Task<List<OrderResponse>> GetOrders()
        {
            var orders = await _repository.GetAllOrders();
            return orders.Select(o => new OrderResponse
            {
                Id = o.Id,
                CustomerId = o.CustomerId,
                ProductId = o.ProductId,
                Quantity = o.Quantity,
                TotalPrice = o.TotalPrice,
                OrderDate = o.OrderDate,
                Status = o.Status.ToString()
            }).ToList();
        }

        public async Task<OrderResponse> GetOrderById(int id)
        {
            var order = await _repository.GetOrderById(id);
            if (order == null) return null;

            return new OrderResponse
            {
                Id = order.Id,
                CustomerId = order.CustomerId,
                ProductId = order.ProductId,
                Quantity = order.Quantity,
                TotalPrice = order.TotalPrice,
                OrderDate = order.OrderDate,
                Status = order.Status.ToString()
            };
        }

        public async Task AddOrder(OrderRequest request)
        {
            var product = await _productRepository.GetProductById(request.ProductId);
            if (product == null || product.Stock < request.Quantity) return;

            var order = new Order
            {
                CustomerId = request.CustomerId,
                ProductId = request.ProductId,
                Quantity = request.Quantity,
                TotalPrice = product.Price * request.Quantity,
                Status = Order.OrderStatus.Pending
            };

            product.Stock -= request.Quantity; // Reduce stock
            await _repository.AddOrder(order);
            await _productRepository.UpdateProduct(product);
        }

        public async Task UpdateOrder(int id, OrderRequest request)
        {
            var order = await _repository.GetOrderById(id);
            if (order == null) return;

            order.Quantity = request.Quantity;
            await _repository.UpdateOrder(order);
        }

        public async Task DeleteOrder(int id)
        {
            await _repository.DeleteOrder(id);
        }
    }
}
