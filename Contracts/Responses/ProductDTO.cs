namespace Contracts.Responses
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public int? DepartmentId { get; set; }
        public DepartmentDTO? Department { get; set; }
    }
}
