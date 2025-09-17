using Microsoft.EntityFrameworkCore;
using SpaceShipViewer.SpaceX.ApplicationCore;
using SpaceShipViewer.SpaceX.ApplicationCore.Contracts;
using SpaceShipViewer.SpaceX.Infrastructure;
using SpaceShipViewer.SpaceX.Infrastructure.Repositories;
using SpaceShipViewer.SpaceX.RestAPI.Mappers;
using SpaceShipViewer.SpaceX.Workers;
using SpaceShipViewer.SpaceX.Workers.Configurations;

namespace SpaceShipViewer.SpaceX.RestAPI
{
    public static class RestApiExtenstions
    {
        public static WebApplicationBuilder AddCommonRestApiServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            return builder;
        }

        public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<SpaceXDbContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddAutoMapper(typeof(RestApiProfile));

            builder.Services.Configure<LaunchesWorkerConfiguration>(builder.Configuration.GetSection("LaunchesWorkerConfiguration"));

            builder.Services.AddWorkerServices();

            builder.Services.AddAplicationCoreServices();

            builder.Services.AddScoped<ILaunchRepository, LaunchRepository>();

            return builder;
        }

        public static WebApplication RunRestApi(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            return app;
        }
    }
}
