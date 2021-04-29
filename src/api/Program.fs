namespace NRK.Dotnetskolen.Api

module Program = 

    open System
    open Microsoft.AspNetCore.Hosting
    open Microsoft.Extensions.Hosting
    open Microsoft.Extensions.DependencyInjection
    open Microsoft.AspNetCore.Builder
    open Giraffe
    open NRK.Dotnetskolen.Domain
    open NRK.Dotnetskolen.Api.Services
    open NRK.Dotnetskolen.Api.DataAccess
    open NRK.Dotnetskolen.Api.HttpHandlers

    let configureApp (getEpgForDate: DateTime -> Epg) (webHostContext: WebHostBuilderContext) (app: IApplicationBuilder) =
        let webApp =
            choose [
                GET  >=> 
                    routef "/epg/%s" (epgHandler getEpgForDate)
                RequestErrors.NOT_FOUND "Not found"
            ]
        app.UseStaticFiles()
           .UseGiraffe webApp

    let configureServices (webHostContext: WebHostBuilderContext) (services: IServiceCollection) =
        services
            .AddGiraffe()
            |> ignore

    let createHostBuilder args =
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(fun webBuilder -> 
                webBuilder
                    .Configure(configureApp (getEpgForDate getAllTransmissions))
                    .ConfigureServices(configureServices)
                |> ignore
            )

    [<EntryPoint>]
    let main argv =
        createHostBuilder(argv).Build().Run()
        0