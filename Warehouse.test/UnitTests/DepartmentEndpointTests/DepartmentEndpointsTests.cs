using FastEndpoints;
using Microsoft.AspNetCore.Http;
using Warehouse.Endpoints.DepartmentEndpoints;
using Warehouse.test.UnitTests.Mocks;
using Warehouse.Mappers.DepartmentMappers;
using Contracts.Responses.Department;
using Contracts.Requests.Department;

namespace Warehouse.test.UnitTests.DepartmentEndpointTests
{
    public class DepartmentEndpointsTests
    {
        [Fact]
        public async Task Get_Departments_SuccessAndReturnCorrectType()
        {
            //arrange
            var repository = MockRepositoryWrapper.GetMock();
            var ep = Factory.Create<GetDepartmentsEndpoint>(repository.Object);
            ep.Map = new DepartmentDTOWithoutRequestMapper();

            //act
            await ep.HandleAsync(default);

            //assert
            Assert.Equal(StatusCodes.Status200OK, ep.HttpContext.Response.StatusCode);
            Assert.IsType<DepartmentsDTO>(ep.Response);
        }

        [Fact]
        public async Task Get_DepartmentById_CorrectId_SuccessAndReturnCorrectType()
        {
            //arrange
            var repository = MockRepositoryWrapper.GetMock();
            var ep = Factory.Create<GetDepartmentEndpont>(repository.Object);
            ep.Map = new DepartmentDTOWithDetailsMapper();
            GetDeleteDepartment getDeleteDepartment = new() { Id = 1 };

            //act
            await ep.HandleAsync(getDeleteDepartment, default);

            //assert
            Assert.Equal(StatusCodes.Status200OK, ep.HttpContext.Response.StatusCode);
            Assert.IsType<DepartmentDTOWithDetails>(ep.Response);
        }

        [Fact]
        public async Task Get_DepartmentById_IncorrectId_NotFound()
        {
            //arrange
            var repository = MockRepositoryWrapper.GetMock();
            var ep = Factory.Create<GetDepartmentEndpont>(repository.Object);
            ep.Map = new DepartmentDTOWithDetailsMapper();
            GetDeleteDepartment getDeleteDepartment = new() { Id = 4 };

            //act
            await ep.HandleAsync(getDeleteDepartment, default);

            //assert
            Assert.Equal(StatusCodes.Status404NotFound, ep.HttpContext.Response.StatusCode);
        }

        [Fact]
        public async Task Delete_DepartmentById_CorrectId_SuccessAndReturnCorrectType()
        {
            //arrange
            var repository = MockRepositoryWrapper.GetMock();
            var ep = Factory.Create<DeleteDepartmentEndpoint>(repository.Object);
            ep.Map = new DepartmentDTOWithDetailsMapper();
            GetDeleteDepartment getDeleteDepartment = new() { Id = 1 };

            //act
            await ep.HandleAsync(getDeleteDepartment, default);

            //assert
            Assert.Equal(StatusCodes.Status200OK, ep.HttpContext.Response.StatusCode);
            Assert.IsType<DepartmentDTOWithDetails>(ep.Response);
        }

        [Fact]
        public async Task Delete_DepartmentById_IncorrectId_NotFound()
        {
            //arrange
            var repository = MockRepositoryWrapper.GetMock();
            var ep = Factory.Create<DeleteDepartmentEndpoint>(repository.Object);
            ep.Map = new DepartmentDTOWithDetailsMapper();
            GetDeleteDepartment getDeleteDepartment = new() { Id = 4 };

            //act
            await ep.HandleAsync(getDeleteDepartment, default);

            //assert
            Assert.Equal(StatusCodes.Status404NotFound, ep.HttpContext.Response.StatusCode);
        }

        [Fact]
        public async Task Post_Department_CorrectModel_SuccessAndReturnCorrectType()
        {
            //arrange
            var repository = MockRepositoryWrapper.GetMock();
            var ep = Factory.Create<PostDepartmentEndpoint>(repository.Object);
            ep.Map = new DepartmentDTOWithDetailsMapper();
            PostDepartment postDepartment = new() { Name = "Tech" };

            //act
            await ep.HandleAsync(postDepartment, default);

            //assert
            Assert.Equal(StatusCodes.Status200OK, ep.HttpContext.Response.StatusCode);
            Assert.IsType<DepartmentDTOWithDetails>(ep.Response);
        }

        [Fact]
        public async Task Put_Department_CorrectModel_SuccessAndReturnCorrectType()
        {
            //arrange
            var repository = MockRepositoryWrapper.GetMock();
            var ep = Factory.Create<PutDepartmentEndpoint>(repository.Object);
            ep.Map = new PutDepartmentMapper();
            PutDepartment putDepartment = new() { Id = 1, Name = "Bikes" };

            //act
            await ep.HandleAsync(putDepartment, default);

            //assert
            Assert.Equal(StatusCodes.Status200OK, ep.HttpContext.Response.StatusCode);
            Assert.IsType<DepartmentDTOWithDetails>(ep.Response);
        }

        [Fact]
        public async Task Put_Department_IncorrectModel_NotFound()
        {
            //arrange
            var repository = MockRepositoryWrapper.GetMock();
            var ep = Factory.Create<PutDepartmentEndpoint>(repository.Object);
            ep.Map = new PutDepartmentMapper();
            PutDepartment putDepartment = new() { Id = 5, Name = "Bikes" };

            //act
            await ep.HandleAsync(putDepartment, default);

            //assert
            Assert.Equal(StatusCodes.Status404NotFound, ep.HttpContext.Response.StatusCode);
        }
    }
}
