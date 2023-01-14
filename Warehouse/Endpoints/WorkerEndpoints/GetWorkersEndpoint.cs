using FastEndpoints;
using Contracts.Responses;
using Warehouse.Mappers;
using Contracts.Interfaces;

namespace Warehouse.Endpoints
{
    [HttpGet("api/workers")]
    public class GetWorkersEndpoint : EndpointWithoutRequest<WorkersDTO>
    {
        private readonly IRepositoryWrapper _repository;
        private readonly WorkerMapper _workerMapper;

        public GetWorkersEndpoint(IRepositoryWrapper repository, WorkerMapper workerMapper)
        {
            _workerMapper = workerMapper;
            _repository = repository;
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            Logger.LogDebug("Retrivering workers");
            var workers = _repository.Worker.GetAllWorkers();

            var workersDto = new WorkersDTO
            {
                Workers = workers.Select(_workerMapper.FromEntity)
            };

            await SendAsync(workersDto, cancellation: ct);
        }
    }
}
