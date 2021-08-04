using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CalcJuros.Services.Api.App
{
    /// <summary>
    /// Pattern de notificação
    /// </summary>
    public class DomainNotificationHandler : INotificationHandler<DomainNotification>
    {
        private List<DomainNotification> _notifications;

        public DomainNotificationHandler()
            => _notifications = new List<DomainNotification>();
        

        public Task Handle(DomainNotification message, CancellationToken cancellationToken)
        {
            _notifications.Add(message);

            return Task.CompletedTask;
        }

        public virtual List<DomainNotification> GetNotifications() 
            => _notifications;

        public virtual bool HasNotifications 
            => GetNotifications().Any();
    }
}