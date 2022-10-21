using MediatR;

namespace TestKendoTreeView.Controllers
{
    public class NotificationHandler1 : INotificationHandler<NotificationModel>
    {
        public Task Handle(NotificationModel notification, CancellationToken cancellationToken)
        {
            Console.WriteLine("From NotificationHandler1 :" + notification.Message);
            return Task.CompletedTask;
        }
    }
}
