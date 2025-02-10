using System.ComponentModel.DataAnnotations.Schema;

namespace Crud_operation_Task_1.Entity
{
    public class Order
    {
        public int Id { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        public Customer Customer { get; set; }
        public Product Product { get; set; }


        public enum OrderStatus
        {
            Pending,
            Completed,
            Cancelled
        }
    }
}