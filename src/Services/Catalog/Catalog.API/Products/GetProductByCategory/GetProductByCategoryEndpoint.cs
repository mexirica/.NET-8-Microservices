namespace Catalog.API.Products.GetProductByCategory;

public class GetProductByCategoryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/category/{category}", async (ISender sender, string category) =>
            {
                var result = await sender.Send(new GetProductByCategoryQuery(category));

                var response = result.Adapt<GetProductByCategoryResult>();

                return Results.Ok(response);
            }).Produces<GetProductByCategoryResult>()
            .ProducesProblem(400)
            .WithSummary("Get product by id")
            .WithDescription("Get product by id");
    }
}