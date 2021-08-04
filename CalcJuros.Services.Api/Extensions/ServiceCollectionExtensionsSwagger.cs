using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;

namespace CalcJuros.Services.Api.Extensions
{
    public static class ServiceCollectionExtensionsSwagger
    {
        public static void ConfigureSwagger(this IServiceCollection services)
        {            
            services.AddSwaggerGen(c =>
            {
                c.UseInlineDefinitionsForEnums();
                c.DescribeAllParametersInCamelCase();
               
                var xmlComments = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, $"{PlatformServices.Default.Application.ApplicationName}.xml");
                c.IncludeXmlComments(xmlComments);
            });
        }
    }
}