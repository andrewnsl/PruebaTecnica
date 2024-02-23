using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Helpers.Extensions
{
    public static class ServiceExtensions
    {       
        public static void AddSwaggerCustom(this IServiceCollection services, string xmlPath, string NameApp)
        {
            string NameApp2 = NameApp;
            string xmlPath2 = xmlPath;
            services.AddSwaggerGen(delegate (SwaggerGenOptions c)
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = NameApp2,
                    Version = "v1",
                    Description = "Servicios correspondientes " + NameApp2,
                    Contact = new OpenApiContact
                    {
                        Name = NameApp2,
                        Email = "andrewns.30@gmail.com"
                    }
                });
                c.IncludeXmlComments(xmlPath2, includeControllerXmlComments: true);           
            });
        }

        public static IServiceCollection AddDbGenericContext<TContext>(this IServiceCollection services) where TContext : DbContext
        {
            return services.AddScoped<DbContext, TContext>();
        }
    }
}
