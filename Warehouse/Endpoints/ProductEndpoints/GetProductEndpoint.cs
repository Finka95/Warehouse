using Contracts.Interfaces;
using Contracts.Requests.Department;
using Contracts.Requests.Product;
using Contracts.Responses.Product;
using FastEndpoints;
using Warehouse.Mappers.ProductMappers;

namespace Warehouse.Endpoints.ProductEndpoints
{
    public class GetProductEndpoint : Endpoint<GetDeleteProduct, ProductDTOWithDetails, ProductDTOWithDetailsMapper>
    {
        private readonly IRepositoryWrapper _repository;

        public override void Configure()
        {
            Get("api/products/{Id}");
            Description(b => b.WithTags("Product"));
            Summary(s =>
            {
                s.Summary = "Get product by Id.";
                s.Params["Id"] = "Product unique identifier";
            });
        }

        public GetProductEndpoint(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public override async Task HandleAsync(GetDeleteProduct product, CancellationToken ct)
        {
            Logger.LogDebug($"Get product by Id");
            var productDB = _repository.Product.GetProductWithDetailsById(product.Id);

            if (productDB == null)
                await SendNotFoundAsync(cancellation: ct);
            else
            {
                var productDTOWithDetails = Map.FromEntity(productDB);
                await SendAsync(productDTOWithDetails, cancellation: ct);
            }
        }
    }
}
