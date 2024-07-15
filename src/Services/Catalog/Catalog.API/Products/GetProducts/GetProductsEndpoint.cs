namespace Catalog.API.Products.GetProducts;

public record GetProductsRequest(int? PageNumber, int? PageSize = 10);

public record GetProductsResponse(IEnumerable<Product> Products);

public class GetProductsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async ([AsParameters] GetProductsRequest request, ISender sender) =>
            {
                var query = request.Adapt<GetProductsQuery>();

                var result = await sender.Send(query);

                var response = result.Adapt<GetProductsResponse>();

                return Results.Ok(response);
            }).WithName("Get product")
            .Produces<GetProductsResponse>(201)
            .ProducesProblem(400)
            .WithSummary("Get product")
            .WithDescription("Get product");
    }
}