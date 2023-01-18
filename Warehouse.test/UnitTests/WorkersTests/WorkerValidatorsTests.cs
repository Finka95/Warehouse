using Contracts.Requests.Worker;
using Warehouse.Validators.WorkerValidators;
using FluentValidation.Results;

namespace Warehouse.test.UnitTests.WorkerEndpointsTests
{
    public class WorkerValidatorsTests
    {
        [Theory]
        [InlineData(null, null, false)]
        [InlineData("", null, false)]
        [InlineData(null, "", false)]
        [InlineData("", "", false)]
        [InlineData("Vlad", "", false)]
        [InlineData("", "Marshyn", false)]
        [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "Marshyn", false)]
        [InlineData("Marshyn", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", false)]
        [InlineData("Rick", "Novak", true)]
        [InlineData("Margaret", "Adelman", true)]
        [InlineData("Nick", "Broadbet", true)]
        public void Post_WorkerValidatorTest(string firstName, string lastName, bool expected)
        {
            //arrange
            PostWorker postWorker = new() { FirstName = firstName, LastName = lastName };
            PostWorkerValidator validator = new();

            //act
            ValidationResult? result = validator.Validate(postWorker);

            //assert
            Assert.Equal(expected, result.IsValid);
        }

        [Theory]
        [InlineData(-1, null, null, false)]
        [InlineData(1, "", null, false)]
        [InlineData(12, null, "", false)]
        [InlineData(12344, "", "", false)]
        [InlineData(0, "Vlad", "", false)]
        [InlineData(65, "", "Marshyn", false)]
        [InlineData(987654321, "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "Marshyn", false)]
        [InlineData(01, "Marshyn", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", false)]
        [InlineData(-4, "Rick", "Novak", false)]
        [InlineData(0, "Margaret", "Adelman", true)]
        [InlineData(123435789, "Nick", "Broadbet", true)]
        [InlineData(1, "Rick", "Novak", true)]
        [InlineData(14560645, "Margaret", "Adelman", true)]
        public void Put_WorkerValidatorTest(int workerId, string firstName, string lastName, bool expected)
        {
            //arrange
            PutWorker putWorker = new() { Id = workerId, FirstName = firstName, LastName = lastName };
            PutWorkerValidator validator = new();

            //act
            ValidationResult? result = validator.Validate(putWorker);

            //assert
            Assert.Equal(expected, result.IsValid);
        }

        [Theory]
        [InlineData(-1, false)]
        [InlineData(0, true)]
        [InlineData(123456778, true)]
        [InlineData(-123456778, false)]
        public void GetDelete_WorkerValidatorTest(int workerId, bool expected)
        {
            //arrange
            GetDeleteWorker getDeleteWorker = new() { Id = workerId };
            GetDeleteWorkerValidator validator = new();

            //act
            ValidationResult? result = validator.Validate(getDeleteWorker);

            //assert
            Assert.Equal(expected, result.IsValid);
        }

        [Theory]
        [InlineData(-1, 12, false)]
        [InlineData(0, -1, false)]
        [InlineData(123456778, 1212323, true)]
        [InlineData(-123456778, 1, false)]
        [InlineData(-123456778, -123456778, false)]
        [InlineData(0, 0, true)]
        public void Change_WorkerDepartmentValidatorTest(int workerId, int departmentId, bool expected)
        {
            //arrange
            ChangeWorkerDepartment getDeleteWorker = new() { WorkerId = workerId , DepartmentId = departmentId };
            ChangeWorkerDepartmentValidator validator = new();

            //act
            ValidationResult? result = validator.Validate(getDeleteWorker);

            //assert
            Assert.Equal(expected, result.IsValid);
        }
    }
}
