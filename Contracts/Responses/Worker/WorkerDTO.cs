namespace Contracts.Responses.Worker
{
    public record WorkerDTO
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}