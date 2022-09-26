using MediatR;

namespace MediatrExample.Products.Commands.AddProduct;

public record AddProductCommand(Product Product) : IRequest<Product>;