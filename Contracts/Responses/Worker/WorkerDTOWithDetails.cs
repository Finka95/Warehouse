using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Responses.Department;

namespace Contracts.Responses.Worker
{
    public record WorkerDTOWithDetails
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public ICollection<DepartmentDTO>? Departments { get; set; }
    }
}
