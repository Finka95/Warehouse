using Contracts.Requests.Worker;
using Entities.Models;
using Warehouse.Mappers.WorkerMappers;
using Contracts.Responses.Worker;
using Contracts.Responses.Department;

namespace Warehouse.test.UnitTests.WorkerEndpointsTests
{
    public class WorkerMapperTests
    {
        public static List<Department> GetDepartments() => new()
        {
            new () { Id = 1, Name = "Gadgets" },
            new () { Id = 2, Name = "Vegitable" }
        };

        [Fact]
        public void Put_WorkerMapperFromEntity_CorrectModel_CorrectTypesAndCountOfDepartments()
        {
            //arrange
            var departments = GetDepartments();
            Worker worker = new Worker()
            {
                Id = 1,
                FirstName = "Sarah",
                LastName = "Connor",
                Departments = departments
            };
            PutWorkerMapper mapper = new();

            //act
            var result = mapper.FromEntity(worker);

            //assert
            Assert.IsType<WorkerDTOWithDetails>(result);
            Assert.Equal("Sarah", result.FirstName);
            Assert.Equal("Connor", result.LastName);
            Assert.Equal(1, result.Id);
            Assert.IsAssignableFrom<ICollection<DepartmentDTO>>(result.Departments);
            Assert.Equal(departments.Count, result?.Departments?.Count);
        }

        [Fact]
        public void Put_WorkerMapperUpdateEntity_CorrectModel_CorrectType()
        {
            //arrange
            var departments = GetDepartments();
            Worker worker = new() { Id = 1, FirstName = "Sarah", LastName = "Connor", Departments = departments };
            PutWorker putWorker = new() { FirstName = "Jes", LastName = null };
            PutWorkerMapper mapper = new();

            //act
            var result = mapper.UpdateEntity(putWorker, worker);

            //assert
            Assert.IsType<Worker>(result);
            Assert.Equal("Jes", result.FirstName);
            Assert.Equal("Connor", result.LastName);
            Assert.Equal(1, result.Id);
            Assert.IsAssignableFrom<ICollection<Department>>(result.Departments);
            Assert.Equal(departments.Count, result?.Departments?.Count);
        }

        [Fact]
        public void WorkerDTOWithDetailsMapper_ToEntity_CorrectModels_CorrectTypeAndNames()
        {
            //arrange
            PostWorker postWorker = new() { FirstName = "Elle", LastName = "Driver" };
            WorkerDTOWithDetailsMapper mapper = new();

            //act
            var result = mapper.ToEntity(postWorker);

            //assert
            Assert.IsType<Worker>(result);
            Assert.Equal(postWorker.FirstName, result.FirstName);
            Assert.Equal(postWorker.LastName, result.LastName);
        }

        [Fact]
        public void WorkerDTOWithDetailsMapper_FromEntity_CorrectModels_CorrectTypeAndNames()
        {
            //arrange
            var departments = GetDepartments();
            Worker postWorker = new() { Id = 1, FirstName = "Elle", LastName = "Driver", Departments = departments };
            WorkerDTOWithDetailsMapper mapper = new();

            //act
            var result = mapper.FromEntity(postWorker);

            //assert
            Assert.IsType<WorkerDTOWithDetails>(result);
            Assert.Equal("Elle", result.FirstName);
            Assert.Equal("Driver", result.LastName);
            Assert.Equal(1, result.Id);
            Assert.IsAssignableFrom<ICollection<DepartmentDTO>>(result.Departments);
            Assert.Equal(departments.Count, result?.Departments?.Count);
        }

        [Fact]
        public void WorkerDTOWithoutRequestMapper_FromEntity_CorrectModels_CorrectTypeAndNames()
        {
            //arrange
            var departments = GetDepartments();
            Worker postWorker = new() { Id = 1, FirstName = "Elle", LastName = "Driver", Departments = departments };
            WorkerDTOWithoutRequestMapper mapper = new();

            //act
            var result = mapper.FromEntity(postWorker);

            //assert
            Assert.IsType<WorkerDTO>(result);
            Assert.Equal("Elle", result.FirstName);
            Assert.Equal("Driver", result.LastName);
            Assert.Equal(1, result.Id);
        }
    }
}
