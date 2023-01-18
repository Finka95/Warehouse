using Contracts.Interfaces;
using Entities.Models;
using Moq;

namespace Warehouse.test.UnitTests.Mocks
{
    internal class MockRepositoryWrapper
    {
        public static Mock<IRepositoryWrapper> GetMock()
        {
            var departments = new List<Department>()
            {
                new Department
                {
                    Id = 1,
                    Name = "Gadgets"
                }
            };

            var workers = new List<Worker>()
            {
                new Worker()
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Silkin",
                    Departments = new List<Department>(departments)
                }
            };

            departments.Add(new Department() { Id = 2, Name = "Vegitables" });

            var products = new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    Name = "TvSet",
                    Department = departments.First(),
                    DepartmentId = departments.First().Id,
                }
            };


            var mock = new Mock<IRepositoryWrapper>();
            var workerRepoMock = MockIWorkerRepository.GetMock(workers);
            var productRepoMock = MockIProductRepository.GetMock(products);
            var departmentRepoMock = MockIDepartmentRepository.GetMock(departments);

            mock.Setup(m => m.Worker).Returns(() => workerRepoMock.Object);
            mock.Setup(m => m.Product).Returns(() => productRepoMock.Object);
            mock.Setup(m => m.Department).Returns(() => departmentRepoMock.Object);
            mock.Setup(m => m.Save()).Callback(() => { return; });

            return mock;
        }
    }
}