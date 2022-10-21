using MediatR;

namespace TestKendoTreeView.Controllers
{
    public class NotificationHandler : INotificationHandler<NotificationModel>
    {
        public Task Handle(NotificationModel notification, CancellationToken cancellationToken)
        {
            Console.WriteLine(notification.Message);
            return Task.CompletedTask;
        }
    }
}
