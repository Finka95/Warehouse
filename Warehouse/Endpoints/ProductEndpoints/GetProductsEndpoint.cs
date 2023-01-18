using Contracts.Interfaces;
using Contracts.Responses.Department;
using Contracts.Responses.Product;
using FastEndpoints;
using Warehouse.Mappers.ProductMappers;

namespace Warehouse.Endpoints.ProductEndpoints
{
    public class GetProductsEndpoint : EndpointWithoutRequest<ProductsDTO, ProductDTOWithoutRequestMapper>
    {
        private readonly IRepositoryWrapper _repository;

        public override void Configure()
        {
            Get("api/products");
            Description(b => b.WithTags("Product"));
            Summary(s =>
            {
                s.Summary = "Get all products.";
            });
        }

        public GetProductsEndpoint(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            Logger.LogDebug("Retrivering products");
            var productsDB = _repository.Product.GetAllProducts();

            var productsDTO = new ProductsDTO
            {
                Products = productsDB.Select(Map.FromEntity)
            };

            await SendAsync(productsDTO, cancellation: ct);
        }
    }
}
