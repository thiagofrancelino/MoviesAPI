using IMDb.Application.Interfaces.IMapper;
using IMDb.Application.Interfaces.IServices;
using IMDb.Application.Interfaces.Services;
using IMDb.Application.Mappers;
using IMDb.Application.Services;
using IMDb.Domain.Repositories;
using IMDb.Repository.Entity;
using IMDb.RepositoryReadOnly.Architecture;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using SimpleInjector;
using System.Linq;

namespace IMDb.Configuration.SimpleInjectorConfig
{
    public static class SimpleInjectorRegisterSettings
    {
        public static Container InitializeComponents(this Container container, IConfiguration Configuration, IApplicationBuilder app)
        {            
            container.RegisterTypes();
            app.UseSimpleInjector(container);

            container.Verify();

            return container;
        }

        public static void RegisterTypes(this Container container)
        {
           //Repositories ReadOnly-------
            var baseRepositoryReadOnlyType = typeof(BaseRepositoryReadOnly);

            var repositoriesReadOnlyAssembly = baseRepositoryReadOnlyType.Assembly;

            var repositoriesReadOnlyRegistrations =
                from type in repositoriesReadOnlyAssembly.GetExportedTypes()
                where type.GetInterfaces().Any()
               // where type.Namespace.StartsWith("IMDb.Domain.Repositories.ReadOnly")
                select new { Interface = type.GetInterfaces().Single(), Implementation = type };

            repositoriesReadOnlyRegistrations.ToList().ForEach(repository =>
                container.Register(repository.Interface, repository.Implementation, Lifestyle.Scoped)
            );

            //Application Services -------
            container.Register<IMovieService, MovieService>(Lifestyle.Scoped);
            container.Register<IUserService, UserService>(Lifestyle.Scoped);
            container.Register<ITokenService, TokenService>(Lifestyle.Scoped);

            //Mappers-------
            container.Register<IUserMapper, UserMapper>(Lifestyle.Scoped);
            container.Register<IMovieMapper, MovieMapper>(Lifestyle.Scoped); ;

            //Repositories----
            container.Register<IUserRepository, UserRepository>(Lifestyle.Scoped);
            container.Register<IMovieRepository, MovieRepository>(Lifestyle.Scoped);
            container.Register<IMovieRateRepository, MovieRateRepository>(Lifestyle.Scoped);

        }
    }
}