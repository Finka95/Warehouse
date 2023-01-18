using Contracts.Responses.Department;

namespace Contracts.Responses.Product
{
    public record ProductDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public int? DepartmentId { get; set; }
    }
}
