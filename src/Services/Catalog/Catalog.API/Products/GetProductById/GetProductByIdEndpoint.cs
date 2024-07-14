namespace Catalog.API.Products.GetProductById;

public class GetProductByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/{id}", async (ISender sender, Guid id) =>
            {
                var result = await sender.Send(new GetProductByIdQuery(id));

                var response = result.Adapt<GetProductByIdResult>();

                return Results.Ok(response);
            })
            .WithName("Get product by id")
            .Produces<GetProductByIdResult>(200)
            .ProducesProblem(400)
            .WithSummary("Get product by id")
            .WithDescription("Get product by id");
    }
}