namespace Contracts.Responses
{
    public class WorkerDTO
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public ICollection<DepartmentDTO>? Departments { get; set; }
    }
}