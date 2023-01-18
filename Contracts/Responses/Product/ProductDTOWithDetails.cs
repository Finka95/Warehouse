using Contracts.Responses.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Responses.Product
{
    public record ProductDTOWithDetails
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DepartmentDTO? Department { get; set; }
    }
}
