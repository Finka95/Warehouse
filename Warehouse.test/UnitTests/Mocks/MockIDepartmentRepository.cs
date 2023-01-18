using Contracts.Interfaces;
using Entities.Models;
using Moq;

namespace Warehouse.test.UnitTests.Mocks
{
    internal class MockIDepartmentRepository
    {
        public static Mock<IDepartmentRepository> GetMock(IEnumerable<Department> departments)
        {
            var mock = new Mock<IDepartmentRepository>();

            // Set up
            mock.Setup(m => m.GetAllDepartments()).Returns(() => departments);
            mock.Setup(m => m.GetDepartmentById(It.IsAny<int>()))
                .Returns((int id) => departments.FirstOrDefault(w => w.Id == id));
            mock.Setup(m => m.GetDepartmentWithDetailsById(It.IsAny<int>()))
                .Returns((int id) => departments.FirstOrDefault(w => w.Id == id));
            mock.Setup(m => m.CreateDepartment(It.IsAny<Department>()))
                .Callback(() => { return; });
            mock.Setup(m => m.UpdateDepartment(It.IsAny<Department>()))
               .Callback(() => { return; });
            mock.Setup(m => m.DeleteDepartment(It.IsAny<Department>()))
               .Callback(() => { return; });

            return mock;
        }
    }
}
