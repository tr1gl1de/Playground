using MediatR;

namespace MediatrExample.Products.Notifications;

public record ProductAddedNotification(Product Product) : INotification;