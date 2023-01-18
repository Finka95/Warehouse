using Contracts.Requests.Worker;
using Contracts.Responses.Department;
using Contracts.Responses.Worker;
using Entities.Models;
using FastEndpoints;

namespace Warehouse.Mappers.WorkerMappers
{
    public class PutWorkerMapper : Mapper<PutWorker, WorkerDTOWithDetails, Worker>
    {
        public override Worker UpdateEntity(PutWorker pw, Worker w)
        {
            w.LastName = pw.LastName ?? w.LastName;
            w.FirstName = pw.FirstName ?? w.FirstName;
            return w;
        }

        public override WorkerDTOWithDetails FromEntity(Worker w) => new()
        {
            Id = w.Id,
            FirstName = w.FirstName,
            LastName = w.LastName,
            Departments = w.Departments?.Select(d => new DepartmentDTO() { Id = d.Id, Name = d.Name }).ToList() ?? null,
        };
    }
}
