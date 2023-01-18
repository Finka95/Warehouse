using FluentValidation.Results;
using Contracts.Requests.Department;
using Warehouse.Validators.DepartmentValidators;

namespace Warehouse.test.UnitTests.DepartmentEndpointTests
{
    public class DepartmentValidatorsTests
    {
        [Theory]
        [InlineData(0, true)]
        [InlineData(1, true)]
        [InlineData(-15, false)]
        [InlineData(123456789, true)]
        public void GetDeleteDepartmentValidatorTest(int departmentId, bool expected)
        {
            //arrange
            GetDeleteDepartment getDeleteDepartment = new() { Id = departmentId };
            GetDeleteDepartmentValidator validator = new();

            //act
            ValidationResult? result = validator.Validate(getDeleteDepartment);

            //assert
            Assert.Equal(expected, result.IsValid);
        }

        [Theory]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData("a", true)]
        [InlineData("Ffffffffffffffff", true)]
        public void PostDepartmentValidatorTest(string departmentName, bool expected)
        {
            //arrange
            PostDepartment postDepartment = new() { Name = departmentName };
            PostDepartmentValidator validator = new();

            //act
            ValidationResult? result = validator.Validate(postDepartment);

            //assert
            Assert.Equal(expected, result.IsValid);
        }


        [Theory]
        [InlineData(1, null, false)]
        [InlineData(15, "", false)]
        [InlineData(123456789, "a", true)]
        [InlineData(-1, "Ffffffffffffffff", false)]
        [InlineData(-15, null, false)]
        public void PutDepartmentValidatorTest(int departmentId, string departmentName, bool expected)
        {
            //arrange
            PutDepartment putDepartment = new() { Id = departmentId, Name = departmentName };
            PutDepartmentValidator validator = new();

            //act
            ValidationResult? result = validator.Validate(putDepartment);

            //assert
            Assert.Equal(expected, result.IsValid);
        }
    }
}
