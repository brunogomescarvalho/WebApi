using System.Reflection;

namespace WebApi.Extensions
{
    public static class SwaggerConfigExtensions
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(opt =>
            {
                // Exibe summary
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                opt.IncludeXmlComments(xmlPath);
            });
        }
    }
}