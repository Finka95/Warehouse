using Contracts.Interfaces;
using Contracts.Requests.Department;
using Contracts.Requests.Product;
using Contracts.Responses.Product;
using FastEndpoints;
using Warehouse.Mappers.ProductMappers;

namespace Warehouse.Endpoints.ProductEndpoints
{
    public class PutProductEndpoint : Endpoint<PutProduct, ProductDTOWithDetails, PutProductMapper>
    {
        private readonly IRepositoryWrapper _repository;

        public override void Configure()
        {
            Put("api/products/{Id}");
            Description(b => b.WithTags("Product"));
            Summary(s =>
            {
                s.Summary = "Update product information.";
            });
        }

        public PutProductEndpoint(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public override async Task HandleAsync(PutProduct product, CancellationToken ct)
        {
            Logger.LogDebug($"Update an product");
            var productDBWithDetails = _repository.Product.GetProductWithDetailsById(product.Id);
            if (productDBWithDetails == null)
            {
                await SendStringAsync("No such product in the database.", statusCode: 404, cancellation: ct);
                return;
            }

            if (product.DepartmentId != null)
            {
                var departmentDBWithDetails = _repository.Department.GetDepartmentWithDetailsById((int)product.DepartmentId);
                if (departmentDBWithDetails == null)
                {
                    await SendStringAsync("No such department in the database.", statusCode: 404, cancellation: ct);
                    return;
                }
                productDBWithDetails!.Department = departmentDBWithDetails;
                productDBWithDetails!.DepartmentId = departmentDBWithDetails!.Id;
            }

            productDBWithDetails = Map.UpdateEntity(product, productDBWithDetails!);
            _repository.Product.UpdateProduct(productDBWithDetails);
            _repository.Save();
            var productDTOWithDetails = Map.FromEntity(productDBWithDetails);
            await SendAsync(productDTOWithDetails, cancellation: ct);
        }
    }
}
