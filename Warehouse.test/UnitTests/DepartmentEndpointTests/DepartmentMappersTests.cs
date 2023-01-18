using Contracts.Responses.Product;
using Entities.Models;
using Warehouse.Mappers.DepartmentMappers;
using Contracts.Responses.Department;
using Contracts.Responses.Worker;
using Contracts.Requests.Department;

namespace Warehouse.test.UnitTests.DepartmentEndpointTests
{
    public class DepartmentMappersTests
    {
        [Fact]
        public void Put_DepartmentMapperFromEntity_CorrectModel_CorrectType()
        {
            //arrange
            List<Product> products = new() { new Product() { Id = 1, Name = "name" }, new Product() { Id = 2, Name = "name2" } };
            List<Worker> workers = new() { new Worker() { Id = 1, FirstName = "Mikaela", LastName = "Banes" },
                    new Worker() { Id = 2, FirstName = "Sam", LastName = "Witwicky" } };
            Department model = new()
            {
                Id = 1,
                Name = "Test",
                Products = products,
                Workers = workers
            };
            PutDepartmentMapper mapper = new();

            //act
            var result = mapper.FromEntity(model);

            //assert
            Assert.IsType<DepartmentDTOWithDetails>(result);
            Assert.Equal("Test", result.Name);
            Assert.Equal(1, result.Id);
            Assert.IsAssignableFrom<ICollection<WorkerDTO>>(result.Workers);
            Assert.IsAssignableFrom<ICollection<ProductDTO>>(result.Products);
            Assert.Equal(workers.Count, result?.Workers?.Count);
            Assert.Equal(products.Count, result?.Products?.Count);
        }

        [Fact]
        public void Put_DepartmentMapperUpdateEntity_CorrectModel_CorrectType()
        {
            //arrange
            PutDepartment putDepartment = new() { Id = 1, Name = "PutDepartment" };
            List<Product> products = new() { new Product() { Id = 1, Name = "Bumblebee" }, new Product() { Id = 2, Name = "Ratchet" } };
            List<Worker> workers = new() { new Worker() { Id = 1, FirstName = "Mikaela", LastName = "Banes" },
                    new Worker() { Id = 2, FirstName = "Sam", LastName = "Witwicky" } };
            Department model = new()
            {
                Id = 1,
                Name = "Test",
                Products = products,
                Workers = workers
            };
            PutDepartmentMapper mapper = new();

            //act
            var result = mapper.UpdateEntity(putDepartment, model);

            //assert
            Assert.IsType<Department>(result);
            Assert.Equal("PutDepartment", result.Name);
            Assert.Equal(1, result.Id);
            Assert.IsAssignableFrom<ICollection<Worker>>(result.Workers);
            Assert.IsAssignableFrom<ICollection<Product>>(result.Products);
            Assert.Equal(workers.Count, result?.Workers?.Count);
            Assert.Equal(products.Count, result?.Products?.Count);
        }

        [Fact]
        public void DepartmentDTOWithDetailsMapperFromEntity_CorrectModel_CorrectType()
        {
            //arrange
            List<Product> products = new() { new Product() { Id = 1, Name = "TvSet" }, new Product() { Id = 2, Name = "Phone" } };
            List<Worker> workers = new() { new Worker() { Id = 1, FirstName = "Jack", LastName = "Daniels" },
                    new Worker() { Id = 2, FirstName = "Gari", LastName = "Bones" } };
            Department model = new()
            {
                Id = 1,
                Name = "Tech",
                Products = products,
                Workers = workers
            };
            DepartmentDTOWithDetailsMapper mapper = new();

            //act
            var result = mapper.FromEntity(model);

            //assert
            Assert.IsType<DepartmentDTOWithDetails>(result);
            Assert.Equal("Tech", result.Name);
            Assert.Equal(1, result.Id);
            Assert.IsAssignableFrom<ICollection<WorkerDTO>>(result.Workers);
            Assert.IsAssignableFrom<ICollection<ProductDTO>>(result.Products);
            Assert.Equal(workers.Count, result?.Workers?.Count);
            Assert.Equal(products.Count, result?.Products?.Count);
        }

        [Fact]
        public void DepartmentDTOWithDetailsMapperToEntity_CorrectModel_CorrectType()
        {
            //arrange
            PostDepartment postDepartment = new()
            {
                Name = "Cars"
            };
            DepartmentDTOWithDetailsMapper mapper = new();

            //act
            var result = mapper.ToEntity(postDepartment);

            //assert
            Assert.IsType<Department>(result);
            Assert.Equal("Cars", result.Name);
        }

        [Fact]
        public void DepartmentDTOWithoutRequestMapperFromEntity_CorrectModel_CorrectType()
        {
            //arrange
            Department model = new()
            {
                Id = 156,
                Name = "Planes"
            };
            DepartmentDTOWithoutRequestMapper mapper = new();

            //act
            var result = mapper.FromEntity(model);

            //assert
            Assert.IsType<DepartmentDTO>(result);
            Assert.Equal("Planes", result.Name);
            Assert.Equal(156, result.Id);
        }
    }
}
