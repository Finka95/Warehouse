namespace Contracts.Responses
{
    public class DepartmentDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public ICollection<ProductDTO>? Products { get; set; }
        public ICollection<WorkerDTO>? Workers { get; set; }
    }
}