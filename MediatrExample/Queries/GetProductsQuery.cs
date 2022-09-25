using MediatR;

namespace MediatrExample.Queries;

public record GetProductsQuery() : IRequest<IEnumerable<Product>>;