using MediatR;

namespace TestKendoTreeView.Controllers
{
    public class NotificationModel: INotification
    {
        public string Message { get; set; }
    }
}
