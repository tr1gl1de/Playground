using MediatR;

namespace MediatrExample.Products.Queries.GetProducts;

public record GetProductsQuery() : IRequest<IEnumerable<Product>>;