namespace Contracts.Responses.Product
{
    public record ProductsDTO
    {
        public IEnumerable<ProductDTO>? Products { get; set; }
    }
}
