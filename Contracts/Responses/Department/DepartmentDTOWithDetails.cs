using Contracts.Responses.Product;
using Contracts.Responses.Worker;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Responses.Department
{
    public record DepartmentDTOWithDetails
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public ICollection<ProductDTO>? Products { get; set; }
        public ICollection<WorkerDTO>? Workers { get; set; }
    }
}
