namespace Basket.API.Basket.GetBasket;

public record GetBasketResponse(ShoppingCart Cart);

public class GetBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/basket/{UserName}", async (string UserName, ISender sender) =>
            {
                var result = await sender.Send(new GetBasketQuery(UserName));

                var response = result.Adapt<GetBasketResponse>();

                return Results.Ok(response);
            }).WithName("Get basket")
            .Produces<GetBasketResponse>()
            .ProducesProblem(400)
            .WithSummary("Get basket")
            .WithDescription("Get basket");
    }
}