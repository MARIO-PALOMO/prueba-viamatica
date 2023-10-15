using consultorio_seguros_api.Contratos;
using consultorio_seguros_api.Modelo;

namespace consultorio_seguros_api.Utilitarios
{
    public static class Dependencias
    {
        public static IServiceCollection AddDependencyDeclaration(this IServiceCollection services)
        {

            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            //Modelos
            services.AddScoped<IMSeguro, MSeguro>();
            services.AddScoped<IMAsegurado, MAsegurado>();
            services.AddScoped<IMSeguroAsegurado, MSeguroAsegurado>();

            return services;
        }
    }
}
