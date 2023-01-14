﻿namespace Entities.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public ICollection<Product>? Products { get;set; }
        public ICollection<Worker>? Workers { get; set; }
    }
}
