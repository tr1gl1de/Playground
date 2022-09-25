using MediatR;
using MediatrExample.Commands;
using MediatrExample.Persistence;

namespace MediatrExample.Handlers;

public class AddProductHandler : IRequestHandler<AddProductCommand, Product>
{
    private readonly FakeDataStore _fakeDataStore;

    public AddProductHandler(FakeDataStore fakeDataStore)
    {
        _fakeDataStore = fakeDataStore;
    }

    public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        await _fakeDataStore.AddProductAsync(request.Product);
        
        return  request.Product;
    }
}