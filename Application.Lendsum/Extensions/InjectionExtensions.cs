//-----------------------------------------------------------------------
// <copyright file = "InjectionExtensions.cs" company="Lendsum">
//     Copyright(c) Lendsum.All rights reserved.
// </copyright>
// <author>Jorge López</author>
//-----------------------------------------------------------------------
namespace Application.Lendsum.Extensions
{
    using Application.Lendsum.Applications;
    using Application.Lendsum.Interfaces;
    using AutoMapper;
    using FluentValidation.AspNetCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System.Reflection;

    /// <summary>Clase para la Inyección de Dependencias entre las interfaces y las clases Application</summary>
    public static class InjectionExtensions
    {
        #region [Methods]
        /// <summary>Método para inyectar las dependencias entre las interfaces y las clases Application</summary>
        /// <param name="services">Servicio para poder agregar las dependencias</param>
        /// <param name="configuration">Configuración necesaria para poder implementar el patrón Singleton</param>
        /// <returns></returns>
        public static IServiceCollection AddInjectionApplication(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddSingleton(configuration);
            services.AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies().
                    Where(p => !p.IsDynamic));
            });
            services.AddCors(options =>
            {
                options.AddPolicy("AllowOriginPolicy",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMemoryCache();
            services.AddScoped<IMazeApplication, MazeApplication>();
            services.AddScoped<IMazeGameApplication, MazeGameApplication>();
            return services;
        }
        #endregion [Methods]
    }
}