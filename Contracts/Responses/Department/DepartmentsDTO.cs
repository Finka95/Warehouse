namespace Contracts.Responses.Department
{
    public record DepartmentsDTO
    {
        public IEnumerable<DepartmentDTO>? Departments { get;set; }
    }
}
