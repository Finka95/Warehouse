using Contracts.Interfaces;
using Contracts.Responses.Department;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Warehouse.Mappers.DepartmentMappers;

namespace Warehouse.Endpoints.DepartmentEndpoints
{
    public class GetDepartmentsEndpoint : EndpointWithoutRequest<DepartmentsDTO, DepartmentDTOWithoutRequestMapper>
    {
        private readonly IRepositoryWrapper _repository;

        public override void Configure()
        {
            Get("api/departments");
            Description(b => b.WithTags("Department"));
            Summary(s =>
            {
                s.Summary = "Get all departments.";
            });
        }

        public GetDepartmentsEndpoint(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            Logger.LogDebug("Retrivering departments");
            var departments = _repository.Department.GetAllDepartments();

            var departmentsDto = new DepartmentsDTO
            {
                Departments = departments.Select(Map.FromEntity)
            };

            await SendAsync(departmentsDto, cancellation: ct);
        }
    }
}