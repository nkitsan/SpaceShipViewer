using SpaceShipViewer.SpaceX.RestAPI;

WebApplication
    .CreateBuilder(args)
    .AddCommonRestApiServices()
    .AddServices()
    .Build()
    .RunRestApi()
    .Run();
