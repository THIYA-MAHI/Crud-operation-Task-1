﻿namespace Crud_operation_Task_1.Entity
{
    public class Product
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
            public int Stock { get; set; }
            public string Category { get; set; }
            public DateTime CreatedAt { get; set; } = DateTime.Now;
        
    }

}