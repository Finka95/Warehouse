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
        private readonly RepositoryContext _context;
        private IWorkerRepository? _workerRepository;
        private IProductRepository? _productRepository;
        private IDepartmentRepository? _departmentRepository;

        public RepositoryWrapper(RepositoryContext context)
        {
            _context = context;
        }

        public IWorkerRepository Worker
        {
            get
            {
                _workerRepository ??= new WorkerRepository(_context);
                return _workerRepository;
            }
        }

        public IProductRepository Product
        {
            get
            {
                _productRepository ??= new ProductRepository(_context);
                return _productRepository;
            }
        }

        public IDepartmentRepository Department
        {
            get
            {
                _departmentRepository ??= new DepartmentRepository(_context);
                return _departmentRepository;
            }
        }

        public void Save() => _context.SaveChanges();
    }
}
