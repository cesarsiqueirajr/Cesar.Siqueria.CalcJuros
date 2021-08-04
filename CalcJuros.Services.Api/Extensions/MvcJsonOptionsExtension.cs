using Microsoft.Extensions.DependencyInjection;

namespace CalcJuros.Services.Api.Extensions
{
    public static class MvcJsonOptionsExtension
    {
        public static IMvcBuilder ConfigureJsonOptions(this IMvcBuilder builder)
        {
            return builder;
        }
    }
}
