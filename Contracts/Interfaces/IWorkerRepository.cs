using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts.Interfaces
{
    public interface IWorkerRepository
    {
        IEnumerable<Worker> GetAllWorkers();
        Worker? GetWorkerById(int id);
        Worker? GetWorkerWithDetails(int id);
        void CreateWorker(Worker worker);
        void UpdateWorker(Worker worker);
        void DeleteWorker(Worker worker);
    }
}
