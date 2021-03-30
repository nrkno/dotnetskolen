module NRK.Dotnetskolen.Api.Startup

open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.DependencyInjection

type public Startup(configuration: IConfiguration) =
    member _.Configuration = configuration

    member _.ConfigureServices(services: IServiceCollection) =
        ()

    member _.Configure(app: IApplicationBuilder, env: IWebHostEnvironment) =
        ()
