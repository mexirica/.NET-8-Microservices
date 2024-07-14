namespace Catalog.API.Products.GetProduct;

public record GetProductsResponse(IEnumerable<Product> Products);

public class GetProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async (ISender sender) =>
            {
                var result = await sender.Send(new GetProductsQuery());

                var response = result.Adapt<GetProductsResponse>();

                return Results.Ok(response);
            }).WithName("Get product")
            .Produces<GetProductsResponse>(201)
            .ProducesProblem(400)
            .WithSummary("Get product")
            .WithDescription("Get product");
    }
}