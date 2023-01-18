using Contracts.Requests.Product;
using FluentValidation.Results;
using Warehouse.Validators.Product;

namespace Warehouse.test.UnitTests.ProductEndpointTests
{
    public class ProductValidatorsTest
    {
        [Theory]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData("TvSet", true)]
        public void Post_ProductValidatorTest(string name, bool expected)
        {
            //arrange
            PostProduct postProduct = new() { Name = name };
            PostProductValidator validator = new();

            //act
            ValidationResult? result = validator.Validate(postProduct);

            //assert
            Assert.Equal(expected, result.IsValid);
        }

        [Theory]
        [InlineData(0, true)]
        [InlineData(1, true)]
        [InlineData(-15, false)]
        [InlineData(123456789, true)]
        public void GetDelete_ProductValidatorTest(int productId, bool expected)
        {
            //arrange
            GetDeleteProduct getDeleteProduct = new() { Id = productId };
            GetDeleteProductValidator validator = new();

            //act
            ValidationResult? result = validator.Validate(getDeleteProduct);

            //assert
            Assert.Equal(expected, result.IsValid);
        }

        [Theory]
        [InlineData(0, "", null, false)]
        [InlineData(15, null, null, false)]
        [InlineData(15, "Toy", null, true)]
        [InlineData(15, null, -1, false)]
        [InlineData(15, null, 15, true)]
        [InlineData(-15, "Toy", 15, false)]
        public void Put_ProductValidatorTest(int productId, string productName, int? departmentId, bool expected)
        {
            //arrange
            PutProduct getDeleteProduct = new() { Id = productId, Name = productName, DepartmentId = departmentId };
            PutProductValidator validator = new();

            //act
            ValidationResult? result = validator.Validate(getDeleteProduct);

            //assert
            Assert.Equal(expected, result.IsValid);
        }
    }
}
