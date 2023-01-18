using FastEndpoints;
using Entities.Models;
using Contracts.Responses.Worker;

namespace Warehouse.Mappers.WorkerMappers
{
    public class WorkerDTOWithoutRequestMapper : ResponseMapper<WorkerDTO, Worker>
    {
        public override WorkerDTO FromEntity(Worker w) => new()
        {
            Id = w.Id,
            FirstName = w.FirstName,
            LastName = w.LastName
        };
    }
}
