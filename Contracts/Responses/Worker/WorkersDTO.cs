namespace Contracts.Responses.Worker
{
    public record WorkersDTO
    {
        public IEnumerable<WorkerDTO>? Workers { get; set; }
    }
}
