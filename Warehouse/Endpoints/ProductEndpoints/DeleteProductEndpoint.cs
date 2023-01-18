using Contracts.Interfaces;
using Contracts.Requests.Department;
using Contracts.Requests.Product;
using Contracts.Responses.Product;
using FastEndpoints;
using Warehouse.Mappers.ProductMappers;

namespace Warehouse.Endpoints.ProductEndpoints
{
    public class DeleteProductEndpoint : Endpoint<GetDeleteProduct, ProductDTOWithDetails, ProductDTOWithDetailsMapper>
    {
        private readonly IRepositoryWrapper _repository;

        public override void Configure()
        {
            Delete("api/products/{Id}");
            Description(b => b.WithTags("Product"));
            Summary(s =>
            {
                s.Summary = "Delete product";
                s.Params["Id"] = "department id description";
            });
        }

        public DeleteProductEndpoint(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public override async Task HandleAsync(GetDeleteProduct product, CancellationToken ct)
        {
            Logger.LogDebug($"Delete product by id");
            var productDBWithDetails = _repository.Product.GetProductWithDetailsById(product.Id);
            if (productDBWithDetails == null)
                await SendNotFoundAsync(cancellation: ct);
            else
            {
                _repository.Product.DeleteProduct(productDBWithDetails);
                _repository.Save();
                var productDTOWithDetails = Map.FromEntity(productDBWithDetails);
                await SendAsync(productDTOWithDetails, cancellation: ct);
            }
        }
    }
}