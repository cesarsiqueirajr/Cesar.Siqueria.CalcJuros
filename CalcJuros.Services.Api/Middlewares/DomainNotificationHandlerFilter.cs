using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using CalcJuros.Services.Api.App;
using CalcJuros.Services.Api.Controllers;

namespace CalcJuros.Services.Api.Middlewares
{

    public class DomainNotificationHandlerFilter : IAsyncResultFilter
    {
        private readonly DomainNotificationHandler _domainNotification;
        
        public DomainNotificationHandlerFilter(INotificationHandler<DomainNotification> notifications)
            => _domainNotification = (DomainNotificationHandler)notifications;

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (_domainNotification.HasNotifications)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.HttpContext.Response.ContentType = "application/json";

                var erros = new ResultMessageResponse<string>(null, _domainNotification.GetNotifications().Select(GetMessageNotifications).ToArray());

                await context.HttpContext.Response.WriteAsync(JsonConvert.SerializeObject(erros));

                return;
            }

            await next();
        }

        private string GetMessageNotifications(DomainNotification notification)
            => notification.Description;
    }
}