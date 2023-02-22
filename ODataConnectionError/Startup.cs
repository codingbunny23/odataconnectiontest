using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ODataConnectionError.Helpers;
using System;

namespace ODataConnectionError;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers(options =>
        {
            options.EnableEndpointRouting = false;
        }).AddOData(options =>
        {
            options.Select().Filter().Expand().Count().OrderBy().SetMaxTop(null);
            options.AddRouteComponents(ODataModelBuilder.GetEdmModel());
        }).AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.PropertyNamingPolicy = null;
        });

        services.AddSingleton(provider =>
        {
            ContextFactory contextFactory = new("SqlDBConnStringOnAzureSqlServerInOurCaseRememberPoolingOff");
            return contextFactory;
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

        app.UseRouting();
        app.UseEndpoints(endpoints => endpoints.MapControllers());
    }
}
