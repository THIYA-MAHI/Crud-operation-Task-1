namespace Crud_operation_Task_1.Entity
{
    public class Order
    {
            public int Id { get; set; }

            public int CustomerId { get; set; }

            public int ProductId { get; set; }

            public int Quantity { get; set; }

            public decimal TotalPrice { get; set; }

            public DateTime OrderDate { get; set; } = DateTime.Now;

            public OrderStatus Status { get; set; } = OrderStatus.Pending;
        
    }
    public enum OrderStatus
    {
        Pending,
        Completed,
        Cancelled
    }
}