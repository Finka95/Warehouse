using FastEndpoints;
using Microsoft.AspNetCore.Http;
using Warehouse.Endpoints.ProductEndpoints;
using Warehouse.test.UnitTests.Mocks;
using Warehouse.Mappers.ProductMappers;
using Contracts.Responses.Product;
using Contracts.Requests.Product;

namespace Warehouse.test.UnitTests.ProductEndpointTests
{
    public class ProductEndpointsTests
    {
        [Fact]
        public async Task Get_Products_SuccessAndReturnCorrectType()
        {
            //arrange
            var repository = MockRepositoryWrapper.GetMock();
            var ep = Factory.Create<GetProductsEndpoint>(repository.Object);
            ep.Map = new ProductDTOWithoutRequestMapper();

            //act
            await ep.HandleAsync(default);

            //assert
            Assert.Equal(StatusCodes.Status200OK, ep.HttpContext.Response.StatusCode);
            Assert.IsType<ProductsDTO>(ep.Response);
        }

        [Fact]
        public async Task Get_ProductById_CorrectId_SuccessAndReturnCorrectType()
        {
            //arrange
            var getDeleteWorker = new GetDeleteProduct() { Id = 1 };
            var repository = MockRepositoryWrapper.GetMock();
            var ep = Factory.Create<GetProductEndpoint>(repository.Object);
            ep.Map = new ProductDTOWithDetailsMapper();

            //act
            await ep.HandleAsync(getDeleteWorker, default);

            //assert
            Assert.Equal(StatusCodes.Status200OK, ep.HttpContext.Response.StatusCode);
            Assert.IsType<ProductDTOWithDetails>(ep.Response);
        }

        [Fact]
        public async Task Get_ProductById_IncorrectId_NotFound()
        {
            //arrange
            var getDeleteWorker = new GetDeleteProduct() { Id = 3 };
            var repository = MockRepositoryWrapper.GetMock();
            var ep = Factory.Create<GetProductEndpoint>(repository.Object);
            ep.Map = new ProductDTOWithDetailsMapper();

            //act
            await ep.HandleAsync(getDeleteWorker, default);

            //assert
            Assert.Equal(StatusCodes.Status404NotFound, ep.HttpContext.Response.StatusCode);
        }

        [Fact]
        public async Task Delete_ProductById_CorrectId_SuccessAndReturnCorrectType()
        {
            //arrange
            var repository = MockRepositoryWrapper.GetMock();
            var ep = Factory.Create<DeleteProductEndpoint>(repository.Object);
            ep.Map = new ProductDTOWithDetailsMapper();

            //act
            await ep.HandleAsync(new GetDeleteProduct() { Id = 1 }, default);

            //assert
            Assert.Equal(StatusCodes.Status200OK, ep.HttpContext.Response.StatusCode);
            Assert.IsType<ProductDTOWithDetails>(ep.Response);
        }

        [Fact]
        public async Task Delete_ProductById_IncorrectId_NotFound()
        {
            //arrange
            var getDeleteWorker = new GetDeleteProduct() { Id = 3 };
            var repository = MockRepositoryWrapper.GetMock();
            var ep = Factory.Create<DeleteProductEndpoint>(repository.Object);
            ep.Map = new ProductDTOWithDetailsMapper();

            //act
            await ep.HandleAsync(getDeleteWorker, default);

            //assert
            Assert.Equal(StatusCodes.Status404NotFound, ep.HttpContext.Response.StatusCode);
        }

        [Fact]
        public async Task Post_Product_CorrectModel_SuccessAndReturnCorrectType()
        {
            //arrange
            PostProduct postProduct = new() { Name = "TvSet", DepartmentId = 1 };
            var repository = MockRepositoryWrapper.GetMock();
            var ep = Factory.Create<PostProductEndpoint>(repository.Object);
            ep.Map = new ProductDTOWithDetailsMapper();

            //act
            await ep.HandleAsync(postProduct, default);

            //assert
            Assert.Equal(StatusCodes.Status200OK, ep.HttpContext.Response.StatusCode);
            Assert.IsType<ProductDTOWithDetails>(ep.Response);
        }

        [Fact]
        public async Task Put_Product_CorrectModel_SuccessAndReturnCorrectType()
        {
            //arrange
            PutProduct putProduct = new() { Id = 1, Name = "TvSet", DepartmentId = 1 };
            var repository = MockRepositoryWrapper.GetMock();
            var ep = Factory.Create<PutProductEndpoint>(repository.Object);
            ep.Map = new PutProductMapper();

            //act
            await ep.HandleAsync(putProduct, default);

            //assert
            Assert.Equal(StatusCodes.Status200OK, ep.HttpContext.Response.StatusCode);
            Assert.IsType<ProductDTOWithDetails>(ep.Response);
        }

        [Theory]
        [InlineData(3, "TvSet", 1)]
        [InlineData(15, "TvSet", 15)]
        [InlineData(1, "TvSet", 15)]
        public async Task Put_Product_IncorrectModel_NotFound(int productId, string productName, int departmentId)
        {
            //arrange
            PutProduct putProduct = new() { Id = productId, Name = productName, DepartmentId = departmentId };
            var repository = MockRepositoryWrapper.GetMock();
            var ep = Factory.Create<PutProductEndpoint>(repository.Object);
            ep.Map = new PutProductMapper();

            //act
            await ep.HandleAsync(putProduct, default);

            //assert
            Assert.Equal(StatusCodes.Status404NotFound, ep.HttpContext.Response.StatusCode);
        }
    }
}
