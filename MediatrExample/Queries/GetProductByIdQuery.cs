using MediatR;

namespace MediatrExample.Queries;

public record GetProductByIdQuery(long Id) : IRequest<Product>;