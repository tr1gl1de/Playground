using MediatR;
using MediatrExample.Persistence;
using MediatrExample.Products.Notifications;

namespace MediatrExample.Products.Handlers;

public class CacheInvalidationHandler : INotificationHandler<ProductAddedNotification>
{
    private readonly FakeDataStore _fakeDataStore;

    public CacheInvalidationHandler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;

    public async Task Handle(ProductAddedNotification notification, CancellationToken cancellationToken)
    {
        await _fakeDataStore.EventOccuredAsync(notification.Product, "Cache invalidated");
        await Task.CompletedTask;
    }
}