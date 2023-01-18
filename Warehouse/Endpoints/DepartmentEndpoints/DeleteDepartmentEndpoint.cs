using Contracts.Interfaces;
using Contracts.Requests.Department;
using Contracts.Requests.Worker;
using Contracts.Responses.Department;
using FastEndpoints;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Mappers.DepartmentMappers;


namespace Warehouse.Endpoints.DepartmentEndpoints
{
    public class DeleteDepartmentEndpoint : Endpoint<GetDeleteDepartment, DepartmentDTOWithDetails, DepartmentDTOWithDetailsMapper>
    {
        private readonly IRepositoryWrapper _repository;

        public override void Configure()
        {
            Delete("api/departments/{Id}");
            Description(b => b.WithTags("Department"));
            Summary(s =>
            {
                s.Summary = "Delete department by Id";
                s.Params["Id"] = "Department unique identifier";
            });
        }

        public DeleteDepartmentEndpoint(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public override async Task HandleAsync(GetDeleteDepartment department, CancellationToken ct)
        {
            Logger.LogDebug($"Delete department by Id");
            var departmentDBWithDetails = _repository.Department.GetDepartmentWithDetailsById(department.Id);
            if (departmentDBWithDetails == null)
                await SendNotFoundAsync(cancellation: ct);
            else
            {
                _repository.Department.DeleteDepartment(departmentDBWithDetails);
                _repository.Save();
                var departmentDTOWithDetails = Map.FromEntity(departmentDBWithDetails);
                await SendAsync(departmentDTOWithDetails, cancellation: ct);
            }
        }
    }
}
