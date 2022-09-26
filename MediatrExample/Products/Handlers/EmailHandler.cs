using MediatR;
using MediatrExample.Persistence;
using MediatrExample.Products.Notifications;

namespace MediatrExample.Products.Handlers;

public class EmailHandler : INotificationHandler<ProductAddedNotification>
{
    private readonly FakeDataStore _fakeDataStore;

    public EmailHandler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;

    public async Task Handle(ProductAddedNotification notification, CancellationToken cancellationToken)
    {
        await _fakeDataStore.EventOccuredAsync(notification.Product, "Email sent");
        await Task.CompletedTask;
    }
}