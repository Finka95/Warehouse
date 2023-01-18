using Contracts.Interfaces;
using Contracts.Requests.Department;
using Contracts.Responses.Department;
using Entities.Models;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Warehouse.Mappers;
using Warehouse.Mappers.DepartmentMappers;

namespace Warehouse.Endpoints.DepartmentEndpoints
{
    public class PostDepartmentEndpoint : Endpoint<PostDepartment, DepartmentDTOWithDetails, DepartmentDTOWithDetailsMapper>
    {
        private readonly IRepositoryWrapper _repository;

        public override void Configure()
        {
            Post("api/departments");
            Description(b => b.WithTags("Department"));
            Summary(s =>
            {
                s.Summary = "Create a new Department.";
            });
        }

        public PostDepartmentEndpoint(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public override async Task HandleAsync(PostDepartment postDepartment, CancellationToken ct)
        {
            Logger.LogDebug("Create a new department");
            Department department = Map.ToEntity(postDepartment);
            _repository.Department.CreateDepartment(department);
            _repository.Save();
            var departmentDTOWithDetails = Map.FromEntity(department);
            await SendAsync(departmentDTOWithDetails, cancellation: ct);
        }
    }
}
