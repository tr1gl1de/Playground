using MediatR;
using MediatrExample.Persistence;
using MediatrExample.Queries;
using NuGet.Protocol.Plugins;

namespace MediatrExample.Handlers;

public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
{
    private readonly FakeDataStore _fakeDataStore;

    public GetProductsHandler(FakeDataStore fakeDataStore)
        => _fakeDataStore = fakeDataStore;

    public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken) 
        => await _fakeDataStore.GetAllProductsAsync();
}