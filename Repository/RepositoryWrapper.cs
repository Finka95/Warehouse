using Contracts.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _context;
        private IWorkerRepository _workerRepository;
        private IProductRepository _productRepository;
        private IDepartmentRepository _departmentRepository;

        public IWorkerRepository Worker
        {
            get
            {
                if (_workerRepository == null) _workerRepository = new WorkerRepository(_context);
                return _workerRepository;
            }
        }

        public IProductRepository Product
        {
            get
            {
                if (_productRepository == null) _productRepository = new ProductRepository(_context);
                return _productRepository;
            }
        }

        public IDepartmentRepository Department
        {
            get
            {
                if (_departmentRepository == null) _departmentRepository = new DepartmentRepository(_context);
                return _departmentRepository;
            }
        }

        public void Save() => _context.SaveChanges();
    }
}
