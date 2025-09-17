using Microsoft.Extensions.DependencyInjection;

namespace SpaceShipViewer.SpaceX.ApplicationCore
{
    public static class ApplicationCoreExtensions
    {
        public static IServiceCollection AddAplicationCoreServices(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AssemblyInfo).Assembly));
        }
    }
}
