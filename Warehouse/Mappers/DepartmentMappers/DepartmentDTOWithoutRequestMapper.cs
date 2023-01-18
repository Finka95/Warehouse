using FastEndpoints;
using Entities.Models;
using Contracts.Responses.Department;

namespace Warehouse.Mappers.DepartmentMappers
{
    public class DepartmentDTOWithoutRequestMapper : ResponseMapper<DepartmentDTO, Department>
    {
        public override DepartmentDTO FromEntity(Department d) => new()
        {
            Id = d.Id,
            Name = d.Name
        };
    }
}
