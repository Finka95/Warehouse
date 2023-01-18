using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Requests.Department
{
    public record PostDepartment
    {
        public string? Name { get; init; }
    }
}
