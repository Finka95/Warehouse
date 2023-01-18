using Contracts.Interfaces;
using Moq;
using Entities.Models;

namespace Warehouse.test.UnitTests.Mocks
{
    internal class MockIWorkerRepository
    {
        public static Mock<IWorkerRepository> GetMock(IEnumerable<Worker> workers)
        {
            var mock = new Mock<IWorkerRepository>();

            // Set up
            mock.Setup(m => m.GetAllWorkers()).Returns(() => workers);
            mock.Setup(m => m.GetWorkerById(It.IsAny<int>()))
                .Returns((int id) => workers.FirstOrDefault(w => w.Id == id));
            mock.Setup(m => m.GetWorkerWithDetailsById(It.IsAny<int>()))
                .Returns((int id) => workers.FirstOrDefault(w => w.Id == id));
            mock.Setup(m => m.CreateWorker(It.IsAny<Worker>()))
                .Callback(() => { return; });
            mock.Setup(m => m.UpdateWorker(It.IsAny<Worker>()))
               .Callback(() => { return; });
            mock.Setup(m => m.DeleteWorker(It.IsAny<Worker>()))
               .Callback(() => { return; });

            return mock;
        }
    }
}