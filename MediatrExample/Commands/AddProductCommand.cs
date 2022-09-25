using MediatR;

namespace MediatrExample.Commands;

public record AddProductCommand(Product Product) : IRequest<Product>;