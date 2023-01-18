using Contracts.Requests.Worker;
using Contracts.Responses.Department;
using Contracts.Responses.Worker;
using Entities.Models;
using FastEndpoints;

namespace Warehouse.Mappers.WorkerMappers
{
    public class WorkerDTOWithDetailsMapper : Mapper<PostWorker, WorkerDTOWithDetails, Worker>
    {
        public override Worker ToEntity(PostWorker pw) => new()
        {
            FirstName = pw.FirstName,
            LastName = pw.LastName
        };

        public override WorkerDTOWithDetails FromEntity(Worker w) => new()
        {
            Id = w.Id,
            FirstName = w.FirstName,
            LastName = w.LastName,
            Departments = w.Departments?.Select(d => new DepartmentDTO() { Id = d.Id, Name = d.Name }).ToArray() ?? null,
        };
    }
}
