using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Requests.Worker
{
    public record ChangeWorkerDepartment
    {
        public int WorkerId { get; init; }
        public int DepartmentId { get; init; }
    }
}
