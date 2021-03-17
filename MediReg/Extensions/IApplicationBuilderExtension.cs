using Microsoft.AspNetCore.Builder;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace API.Extensions
{
    public static class IApplicationBuilderExtension
    {
        public static void RegisterSwaggerUI(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "OlympReg V1");
                x.RoutePrefix = string.Empty;
                x.DefaultModelExpandDepth(3);
                x.DefaultModelRendering(ModelRendering.Example);
                x.DefaultModelsExpandDepth(-1);
                x.DisplayOperationId();
                x.DisplayRequestDuration();
                x.DocExpansion(DocExpansion.None);
                x.EnableDeepLinking();
                x.EnableFilter();
                x.ShowExtensions();
            });
        }
    }
}
