using FastEndpoints;
using Warehouse.Mappers.DepartmentMappers;
using Contracts.Requests.Department;
using Contracts.Interfaces;
using Contracts.Responses.Department;

namespace Warehouse.Endpoints.DepartmentEndpoints
{
    public class PutDepartmentEndpoint : Endpoint<PutDepartment, DepartmentDTOWithDetails, PutDepartmentMapper>
    {
        private readonly IRepositoryWrapper _repository;

        public override void Configure()
        {
            Put("api/departments/{Id}");
            Description(b => b.WithTags("Department"));
            Summary(s =>
            {
                s.Summary = "Update departments information.";
                s.ExampleRequest = new PutDepartment() { Id = 1, Name = "Pipe" };
            });
        }

        public PutDepartmentEndpoint(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public override async Task HandleAsync(PutDepartment putDepartment, CancellationToken ct)
        {
            Logger.LogDebug($"Update an department");
            var departmentDBWithDetails = _repository.Department.GetDepartmentWithDetailsById(putDepartment.Id);
            if (departmentDBWithDetails == null)
                await SendNotFoundAsync(cancellation: ct);
            else
            {
                departmentDBWithDetails = Map.UpdateEntity(putDepartment, departmentDBWithDetails);
                _repository.Department.UpdateDepartment(departmentDBWithDetails);
                _repository.Save();
                var departmentDTOWithDetails = Map.FromEntity(departmentDBWithDetails);
                await SendAsync(departmentDTOWithDetails, cancellation: ct);
            }
        }
    }
}
