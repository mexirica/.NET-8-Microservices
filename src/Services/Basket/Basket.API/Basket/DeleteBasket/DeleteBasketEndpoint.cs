namespace Basket.API.Basket.DeleteBasket;

public record DeleteBasketResponse(bool IsSuccess);

public class DeleteBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/basket/{UserName}", async (string UserName, ISender sender) =>
            {
                var command = new DeleteBasketCommand(UserName);

                var result = await sender.Send(command);

                var response = result.Adapt<DeleteBasketResponse>();

                return Results.Ok(response);
            }).WithName("Delete basket")
            .Produces<DeleteBasketResponse>()
            .ProducesProblem(400)
            .WithSummary("Delete basket")
            .WithDescription("Delete basket");
    }
}