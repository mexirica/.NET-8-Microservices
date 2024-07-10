using MediatR;

namespace BuildingBlocks.CQRS;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TResponse : notnull
    where TQuery : IQuery<TResponse>
{
}