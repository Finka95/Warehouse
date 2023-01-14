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
    public class WorkerRepository : RepositoryBase<Worker>, IWorkerRepository
    {
        public WorkerRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateWorker(Worker worker) => Create(worker);

        public void UpdateWorker(Worker worker) => Update(worker);

        public void DeleteWorker(Worker worker) => Delete(worker);

        public IEnumerable<Worker> GetAllWorkers()
        {
            return FindAll().ToList();
        }

        public Worker? GetWorkerById(int id)
        {
            return FindByConditions(worker => worker.Id == id)
                .FirstOrDefault();
        }

        public Worker? GetWorkerWithDetails(int id)
        {
            return FindByConditions(worker => worker.Id == id)
                .Include(w => w.Departments)
                .FirstOrDefault();
        }
    }
}
