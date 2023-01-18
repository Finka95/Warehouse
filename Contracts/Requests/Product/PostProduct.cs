using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Requests.Product
{
    public record PostProduct
    {
        public string? Name { get; set; }
        public int DepartmentId { get; set; }
    }
}
