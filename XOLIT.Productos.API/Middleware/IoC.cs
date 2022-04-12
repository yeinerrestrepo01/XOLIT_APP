
using CaseLink.Core.Infrastructure.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using XOLIT.ShoppingCart.Infrastructure.GenericRepository;
using XOLIT.ShoppingCart.Infrastructure.Repository;

namespace XOLIT.ShoppingCart.API.Middleware
{
    public static class IoC
    {
        /// <summary>
        ///     Adds the dependency.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns>IServiceCollection.</returns>
        /// <remarks>Jhoel Aicardi</remarks>
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            // Infrastructure

            #region Infrastructure

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

            #endregion

            //Services

            #region Services

            //services.AddTransient<IMedicalSpecialityService, MedicalSpecialityService>();
            #endregion


            //Repository

            #region Repository

            services.AddTransient<IProductoRepository, ProductoRepository>();
            #endregion


            return services;
        }
    }
}