using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace CalcJuros.Services.Api.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class ApplicationBuilderExtensionsSwagger
    {
        public static void UseSwaggerInApplication(this IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "Teste calculo juros .Net Core");
            });
        }
    }
}
