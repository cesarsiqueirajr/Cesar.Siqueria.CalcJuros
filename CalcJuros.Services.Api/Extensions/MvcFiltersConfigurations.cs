using CalcJuros.Services.Api.Middlewares;
using Microsoft.AspNetCore.Mvc;

namespace CalcJuros.Services.Api.Extensions
{
    public static class MvcFiltersConfigurations
    {
        public static MvcOptions ConfigureFilters(this MvcOptions options)
        {
            options.Filters.Add<DomainNotificationHandlerFilter>();

            return options;
        }
    }
}