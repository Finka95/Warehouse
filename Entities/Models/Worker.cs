namespace Entities.Models
{
    public class Worker
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set;}

        public ICollection<Department>? Departments { get; set; }

        public Worker()
        {
            Departments = new List<Department>();
        }
    }
}