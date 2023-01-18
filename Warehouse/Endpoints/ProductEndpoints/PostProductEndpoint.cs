using Contracts.Interfaces;
using Contracts.Requests.Department;
using Contracts.Requests.Product;
using Contracts.Responses.Product;
using Entities.Models;
using FastEndpoints;
using Warehouse.Mappers.ProductMappers;

namespace Warehouse.Endpoints.ProductEndpoints
{
    public class PostProductEndpoint : Endpoint<PostProduct, ProductDTOWithDetails, ProductDTOWithDetailsMapper>
    {
        private readonly IRepositoryWrapper _repository;

        public override void Configure()
        {
            Post("api/products");
            Description(b => b.WithTags("Product"));
            Summary(s =>
            {
                s.Summary = "Create a new Product.";
            });
        }

        public PostProductEndpoint(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public override async Task HandleAsync(PostProduct postProduct, CancellationToken ct)
        {
            Logger.LogDebug("Create a new product");
            Product product = Map.ToEntity(postProduct);
            _repository.Product.CreateProduct(product);
            _repository.Save();
            var productDTOWithDetails = Map.FromEntity(product);
            await SendAsync(productDTOWithDetails, cancellation: ct);
        }
    }
}
