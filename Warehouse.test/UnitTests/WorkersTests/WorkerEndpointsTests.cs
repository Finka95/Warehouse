using FastEndpoints;
using Warehouse.Endpoints.WorkerEndpoints;
using Microsoft.AspNetCore.Http;
using Warehouse.test.UnitTests.Mocks;
using Contracts.Requests.Worker;
using Contracts.Responses.Worker;
using Warehouse.Mappers.WorkerMappers;

namespace Warehouse.test.UnitTests.WorkerEndpointsTests
{
    public class WorkerEndpointsTests
    {
        [Fact]
        public async Task Get_Workers_SuccessAndReturnCorrectType()
        {
            //arrange
            var repository = MockRepositoryWrapper.GetMock();
            //var repository = A.Fake<IRepositoryWrapper>();
            var ep = Factory.Create<GetWorkersEndpoint>(repository.Object);
            ep.Map = new WorkerDTOWithoutRequestMapper();

            //act
            await ep.HandleAsync(default);

            //assert
            Assert.Equal(StatusCodes.Status200OK, ep.HttpContext.Response.StatusCode);
            Assert.IsType<WorkersDTO>(ep.Response);
        }

        [Fact]
        public async Task Get_WorkerById_IncorrectId_NotFound()
        {
            //arrange
            var repository = MockRepositoryWrapper.GetMock();
            var ep = Factory.Create<GetWorkerEndpoint>(repository.Object);
            ep.Map = new WorkerDTOWithDetailsMapper();

            //act
            await ep.HandleAsync(new GetDeleteWorker { Id = 3 }, default);

            //assert
            Assert.Equal(StatusCodes.Status404NotFound, ep.HttpContext.Response.StatusCode);
        }

        [Fact]
        public async Task Get_WorkerById_CorrectId_SuccessAndReturnCorrectType()
        {
            //arrange
            var repository = MockRepositoryWrapper.GetMock();
            var ep = Factory.Create<GetWorkerEndpoint>(repository.Object);
            ep.Map = new WorkerDTOWithDetailsMapper();

            //act
            await ep.HandleAsync(new GetDeleteWorker { Id = 1 }, default);

            //assert
            Assert.IsType<WorkerDTOWithDetails>(ep.Response);
            Assert.False(ep.ValidationFailed);
        }

        [Fact]
        public async Task Post_Worker_CorrectModel_SuccessAndReturnCorrectType()
        {
            //arrange
            var repository = MockRepositoryWrapper.GetMock();
            var ep = Factory.Create<PostWorkerEndpoint>(repository.Object);
            ep.Map = new WorkerDTOWithDetailsMapper();
            PostWorker postWorker = new() { FirstName = "FirstNameTest", LastName = "FirstNameTest" };

            //act
            await ep.HandleAsync(postWorker, default);
            var responseWorker = ep.Response;

            //assert
            Assert.IsType<WorkerDTOWithDetails>(responseWorker);
            Assert.Equal(responseWorker.FirstName, postWorker.FirstName);
            Assert.Equal(responseWorker.LastName, postWorker.LastName);
        }

        [Fact]
        public async Task Put_WorkerById_CorrectModel_SuccessAndReturnCorrectType()
        {
            //arrange
            var repository = MockRepositoryWrapper.GetMock();
            var ep = Factory.Create<PutWorkerEndpoint>(repository.Object);
            ep.Map = new PutWorkerMapper();
            PutWorker putWorker = new() { Id = 1, FirstName = "PutFirstName", LastName = "PutLastName" };

            //act
            await ep.HandleAsync(putWorker, default);
            var responseWorker = ep.Response;

            //assert
            Assert.IsType<WorkerDTOWithDetails>(responseWorker);
            Assert.Equal(responseWorker.FirstName, putWorker.FirstName);
            Assert.Equal(responseWorker.LastName, putWorker.LastName);
        }

        [Fact]
        public async Task Put_WorkerById_IncorrectId_NotFound()
        {
            //arrange
            var repository = MockRepositoryWrapper.GetMock();
            var ep = Factory.Create<PutWorkerEndpoint>(repository.Object);
            ep.Map = new PutWorkerMapper();
            PutWorker putWorker = new() { Id = 3, FirstName = "PutFirstName", LastName = "PutLastName" };

            //act
            await ep.HandleAsync(putWorker, default);

            //assert
            Assert.Equal(StatusCodes.Status404NotFound, ep.HttpContext.Response.StatusCode);
        }

        [Fact]
        public async Task Delete_Worker_CorrectId_SuccessAndReturnCorrectType()
        {
            //arrange
            var repository = MockRepositoryWrapper.GetMock();
            var ep = Factory.Create<DeleteWorkerEndpoint>(repository.Object);
            ep.Map = new WorkerDTOWithDetailsMapper();
            GetDeleteWorker deleteWorker = new() { Id = 1 };

            //act
            await ep.HandleAsync(deleteWorker, default);
            var responseWorker = ep.Response;

            //assert
            Assert.IsType<WorkerDTOWithDetails>(responseWorker);

            // Values from MockRepositoryWrapper
            Assert.Equal("John", responseWorker.FirstName);
            Assert.Equal("Silkin", responseWorker.LastName);
        }

        [Fact]
        public async Task Delete_Worker_IncorrectId_NotFound()
        {
            //arrange
            var repository = MockRepositoryWrapper.GetMock();
            var ep = Factory.Create<DeleteWorkerEndpoint>(repository.Object);
            ep.Map = new WorkerDTOWithDetailsMapper();
            GetDeleteWorker deleteWorker = new() { Id = 3 };

            //act
            await ep.HandleAsync(deleteWorker, default);

            //assert
            Assert.Equal(StatusCodes.Status404NotFound, ep.HttpContext.Response.StatusCode);
        }

        [Fact]
        public async Task Delete_DepartmentFromWorker_CorrectIds_SuccessAndReturnCorrectType()
        {
            //arrange
            var repository = MockRepositoryWrapper.GetMock();
            var ep = Factory.Create<DeleteDepartmentFromWorkerEndpoint>(repository.Object);
            ep.Map = new WorkerDTOWithDetailsMapper();
            ChangeWorkerDepartment changeWorkerDepartment = new() { WorkerId = 1 , DepartmentId = 1};

            //act
            await ep.HandleAsync(changeWorkerDepartment, default);
            var responseWorker = ep.Response;

            //assert
            Assert.IsType<WorkerDTOWithDetails>(responseWorker);
            // Values from MockRepositoryWrapper
            Assert.Equal("John", responseWorker.FirstName);
            Assert.Equal("Silkin", responseWorker.LastName);
        }

        [Theory]
        [InlineData(1, 3, 404)]
        [InlineData(3, 1, 404)]
        public async Task Delete_DepartmentFromWorker_IncorrectIds_NotFound(int workerId, int departmentId, int statusCode)
        {
            //arrange
            var repository = MockRepositoryWrapper.GetMock();
            var ep = Factory.Create<DeleteDepartmentFromWorkerEndpoint>(repository.Object);
            ep.Map = new WorkerDTOWithDetailsMapper();
            ChangeWorkerDepartment changeWorkerDepartment = new() { WorkerId = workerId, DepartmentId = departmentId };

            //act
            await ep.HandleAsync(changeWorkerDepartment, default);

            //assert
            Assert.Equal(statusCode, ep.HttpContext.Response.StatusCode);
        }

        [Fact]
        public async Task Post_DepartmentToWorker_CorrectIds_SuccessAndReturnCorrectType()
        {
            //arrange
            var repository = MockRepositoryWrapper.GetMock();
            var ep = Factory.Create<PostDepartmentToWorkerEndpoint>(repository.Object);
            ep.Map = new WorkerDTOWithDetailsMapper();
            ChangeWorkerDepartment changeWorkerDepartment = new() { WorkerId = 1 , DepartmentId = 2};

            //act
            await ep.HandleAsync(changeWorkerDepartment, default);
            var responseWorker = ep.Response;

            //assert
            Assert.IsType<WorkerDTOWithDetails>(responseWorker);
            // Values from MockRepositoryWrapper
            Assert.Equal("John", responseWorker.FirstName);
            Assert.Equal("Silkin", responseWorker.LastName);
            Assert.NotNull(responseWorker?.Departments?.FirstOrDefault(d => d.Id == 2));
        }

        [Theory]
        [InlineData(1, 3, 404)]
        [InlineData(3, 1, 404)]
        public async Task Post_DepartmentToWorker_IncorrectIds_NotFound(int workerId, int departmentId, int statusCode)
        {
            //arrange
            var repository = MockRepositoryWrapper.GetMock();
            var ep = Factory.Create<PostDepartmentToWorkerEndpoint>(repository.Object);
            ep.Map = new WorkerDTOWithDetailsMapper();
            ChangeWorkerDepartment changeWorkerDepartment = new() { WorkerId = workerId, DepartmentId = departmentId };

            //act
            await ep.HandleAsync(changeWorkerDepartment, default);

            //assert
            Assert.Equal(statusCode, ep.HttpContext.Response.StatusCode);
        }
    }
}
