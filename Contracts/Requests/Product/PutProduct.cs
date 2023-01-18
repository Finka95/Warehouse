using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Requests.Product
{
    public record PutProduct
    {
        public int Id { get; init; }
        public string? Name { get; init; }
        public int? DepartmentId { get; init; }
    }
}
