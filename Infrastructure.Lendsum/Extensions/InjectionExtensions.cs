//-----------------------------------------------------------------------
// <copyright file = "InjectionExtensions.cs" company="Lendsum">
//     Copyright(c) Lendsum.All rights reserved.
// </copyright>
// <author>Jorge López</author>
//-----------------------------------------------------------------------
namespace Infrestructure.Lendsum.Extensions
{
    using Infrestructure.Lendsum.Persistences.Contexts;
    using Infrestructure.Lendsum.Persistences.Interfaces;
    using Infrestructure.Lendsum.Persistences.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>Clase para la Inyección de Dependencias entre las interfaces y las clases UnitOfWork, GenericRepository</summary>
    public static class InjectionExtensions
    {
        #region [Methods]
        /// <summary>Método para inyectar las dependencias entre las interfaces y las clases UnitOfWork, GenericRepository</summary>
        /// <param name="services">Servicio para poder agregar las dependencias</param>
        /// <param name="configuration">Configuración necesaria para poder implementar el DbContext</param>
        /// <returns></returns>
        public static IServiceCollection AddInjectionInfrestructure(this IServiceCollection services, IConfiguration configuration)
        {
            string? assembly = typeof(LendsumContext).Assembly.FullName;
            services.AddDbContext<LendsumContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("LendsumConnection"), b => b.MigrationsAssembly(assembly)),
                ServiceLifetime.Transient);

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }
        #endregion [Methods]
    }
}