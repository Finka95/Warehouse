using Contracts.Interfaces;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateProduct(Product product) => Create(product);

        public void UpdateProduct(Product product) => Update(product);

        public void DeleteProduct(Product product) => Delete(product);

        public IEnumerable<Product> GetAllProducts()
        {
            return FindAll().ToList();
        }

        public Product? GetProductById(int id)
        {
            return FindByConditions(p => p.Id == id)
                .FirstOrDefault();
        }
    }
}
