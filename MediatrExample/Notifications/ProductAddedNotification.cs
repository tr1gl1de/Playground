using MediatR;

namespace MediatrExample.Notifications;

public record ProductAddedNotification(Product Product) : INotification;