using Contracts.Interfaces;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    internal class DepartmentRepository : RepositoryBase<Department>, IDepartmentRepository
    {
        public DepartmentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateDepartment(Department department) => Create(department);

        public void UpdateDepartment(Department department) => Update(department);

        public void DeleteDepartment(Department department) => Delete(department);

        public IEnumerable<Department> GetAllDepartments()
        {
            return FindAll().ToList();
        }

        public Department? GetDepartmentById(int id)
        {
            return FindByConditions(d => d.Id == id).FirstOrDefault();
        }

        public Department? GetDepartmentWithDetailsById(int id)
        {
            return FindByConditions(d => d.Id == id)
                .Include(d => d.Workers)
                .Include(d => d.Products)
                .FirstOrDefault();
        }
    }
}
