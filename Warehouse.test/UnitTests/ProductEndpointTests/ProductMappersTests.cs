using Entities.Models;
using Warehouse.Mappers.ProductMappers;
using Contracts.Responses.Product;
using Contracts.Requests.Product;

namespace Warehouse.test.UnitTests.ProductEndpointTests
{
    public class ProductMappersTests
    {
        [Fact]
        public void Put_ProductMapperFromEntity_CorrectModel_CorrectType()
        {
            //arrange
            Product product = new()
            {
                Id = 1,
                Name = "Test"
            };
            PutProductMapper mapper = new();

            //act
            var result = mapper.FromEntity(product);

            //assert
            Assert.IsType<ProductDTOWithDetails>(result);
            Assert.Equal("Test", result.Name);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public void Put_ProductMapperUpdateEntity_CorrectModel_CorrectType()
        {
            //arrange
            Product product = new()
            {
                Id = 1,
                Name = "Test"
            };
            PutProduct putProduct = new()
            {
                Id = 1,
                Name = "putProduct"
            };
            PutProductMapper mapper = new();

            //act
            var result = mapper.UpdateEntity(putProduct, product);

            //assert
            Assert.IsType<Product>(result);
            Assert.Equal("putProduct", result.Name);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public void ProductDTOWithDetailsMapperFromEntity_CorrectModel_CorrectType()
        {
            //arrange
            Product product = new()
            {
                Id = 1,
                Name = "Test"
            };
            ProductDTOWithDetailsMapper mapper = new();

            //act
            var result = mapper.FromEntity(product);

            //assert
            Assert.IsType<ProductDTOWithDetails>(result);
            Assert.Equal("Test", result.Name);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public void ProductDTOWithDetailsMapperToEntity_CorrectModel_CorrectType()
        {
            //arrange
            PostProduct postProduct = new()
            {
                Name = "Test",
                DepartmentId = 1
            };
            ProductDTOWithDetailsMapper mapper = new();

            //act
            var result = mapper.ToEntity(postProduct);

            //assert
            Assert.IsType<Product>(result);
            Assert.Equal("Test", result.Name);
            Assert.Equal(1, result.DepartmentId);
        }

        [Fact]
        public void ProductDTOWithoutRequestMapperFromEntity_CorrectModel_CorrectType()
        {
            //arrange
            Product product = new()
            {
                Id = 1,
                Name = "Test"
            };
            ProductDTOWithoutRequestMapper mapper = new();

            //act
            var result = mapper.FromEntity(product);

            //assert
            Assert.IsType<ProductDTO>(result);
            Assert.Equal("Test", result.Name);
            Assert.Equal(1, result.Id);
        }
    }
}
