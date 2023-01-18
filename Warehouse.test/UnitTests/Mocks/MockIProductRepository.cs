using Contracts.Interfaces;
using Entities.Models;
using Moq;

namespace Warehouse.test.UnitTests.Mocks
{
    internal class MockIProductRepository
    {
        public static Mock<IProductRepository> GetMock(IEnumerable<Product> products)
        {
            var mock = new Mock<IProductRepository>();

            // Set up
            mock.Setup(m => m.GetAllProducts()).Returns(() => products);
            mock.Setup(m => m.GetProductById(It.IsAny<int>()))
                .Returns((int id) => products.FirstOrDefault(w => w.Id == id));
            mock.Setup(m => m.GetProductWithDetailsById(It.IsAny<int>()))
                .Returns((int id) => products.FirstOrDefault(w => w.Id == id));
            mock.Setup(m => m.CreateProduct(It.IsAny<Product>()))
                .Callback(() => { return; });
            mock.Setup(m => m.UpdateProduct(It.IsAny<Product>()))
               .Callback(() => { return; });
            mock.Setup(m => m.DeleteProduct(It.IsAny<Product>()))
               .Callback(() => { return; });

            return mock;
        }
    }
}
