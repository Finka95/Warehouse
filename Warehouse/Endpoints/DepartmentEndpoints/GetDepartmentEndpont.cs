using Contracts.Interfaces;
using Microsoft.Extensions.Logging;
using Contracts.Requests.Department;
using Warehouse.Mappers.DepartmentMappers;
using FastEndpoints;
using Contracts.Responses.Department;

namespace Warehouse.Endpoints.DepartmentEndpoints
{
    public class GetDepartmentEndpont : Endpoint<GetDeleteDepartment, DepartmentDTOWithDetails, DepartmentDTOWithDetailsMapper>
    {
        private readonly IRepositoryWrapper _repository;

        public override void Configure()
        {
            Get("api/departments/{Id}");
            Description(b => b.WithTags("Department"));
            Summary(s =>
            {
                s.Summary = "Get department by Id.";
                s.Params["Id"] = "Department unique identifier";
            });
        }

        public GetDepartmentEndpont(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public override async Task HandleAsync(GetDeleteDepartment department, CancellationToken ct)
        {
            Logger.LogDebug($"Get department by id");
            var departmentDB = _repository.Department.GetDepartmentWithDetailsById(department.Id);

            if (departmentDB == null)
                await SendNotFoundAsync(cancellation: ct);
            else
            {
                var departmentDTOWithDetails = Map.FromEntity(departmentDB);
                await SendAsync(departmentDTOWithDetails, cancellation: ct);
            }
        }
    }
}
