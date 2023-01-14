using FastEndpoints;
using Contracts.Responses;
using Entities.Models;

namespace Warehouse.Mappers
{
    public class WorkerMapper : Mapper<int, WorkerDTO, Worker>
    {
        public override WorkerDTO FromEntity(Worker w)
        {
            return new WorkerDTO
            {
                Id = w.Id,
                FirstName= w.FirstName,
                LastName= w.LastName
            };
        }
    }
}
