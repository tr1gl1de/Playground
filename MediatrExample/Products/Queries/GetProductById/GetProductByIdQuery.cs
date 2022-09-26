using MediatR;

namespace MediatrExample.Products.Queries.GetProductById;

public record GetProductByIdQuery(long Id) : IRequest<Product>;