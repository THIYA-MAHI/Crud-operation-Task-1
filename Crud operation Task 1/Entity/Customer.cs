﻿namespace Crud_operation_Task_1.Entity
{
    public class Customer
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string Address { get; set; }
            public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
 }


