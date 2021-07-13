namespace NRK.Dotnetskolen.Api

module Program =
    open System
    open Microsoft.AspNetCore.Hosting
    open Microsoft.Extensions.DependencyInjection
    open Microsoft.AspNetCore.Builder
    open Microsoft.Extensions.Hosting
    open Giraffe

    open NRK.Dotnetskolen.Api.DataAccess
    open NRK.Dotnetskolen.Api.HttpHandlers
    open NRK.Dotnetskolen.Api.Services
    open NRK.Dotnetskolen.Domain

    let configureApp
        (getEpgForDate : DateTime -> Epg)
        (webHostContext: WebHostBuilderContext)
        (app: IApplicationBuilder) =
        let webApp = GET >=> routef "/epg/%s" (epgHandler getEpgForDate)
        app.UseGiraffe webApp

    let configureServices (webHostContext: WebHostBuilderContext) (services: IServiceCollection) =
        services.AddGiraffe() |> ignore

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
