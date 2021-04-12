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

let configureApp (webHostContext: WebHostBuilderContext) (app: IApplicationBuilder) =
    let getEpgForDate = app.ApplicationServices.GetRequiredService<DateTime -> Epg>()
    let webApp =
        choose [
            GET  >=> 
                routef "/epg/%s" (epgHandler getEpgForDate)
            RequestErrors.NOT_FOUND "Not found"
        ]
    app.UseGiraffe webApp

let configureServices (webHostContext: WebHostBuilderContext) (services: IServiceCollection) =
    let getEpgForDate = getEpgForDate getAllTransmissions
    services
        .AddGiraffe()
        .AddSingleton<DateTime -> Epg>(getEpgForDate) 
        |> ignore

let CreateHostBuilder args =
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(fun webBuilder -> 
            webBuilder
                .Configure(configureApp)
                .ConfigureServices(configureServices)
            |> ignore
        )

[<EntryPoint>]
let main argv =
    CreateHostBuilder(argv).Build().Run()
    0