namespace NRK.Dotnetskolen.Api

module Program = 

    open Microsoft.Extensions.Hosting
    open Microsoft.AspNetCore.Hosting
    open Microsoft.AspNetCore.Builder
    open Microsoft.Extensions.DependencyInjection
    open Giraffe

    let configureApp (webHostContext: WebHostBuilderContext) (app: IApplicationBuilder) =
        let webApp = route "/ping" >=> text "pong"
        app.UseGiraffe webApp

    let configureServices (webHostContext: WebHostBuilderContext) (services: IServiceCollection) =
        services.AddGiraffe() |> ignore

    let createHostBuilder args =
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(fun webHostBuilder ->
                webHostBuilder
                    .Configure(configureApp)
                    .ConfigureServices(configureServices) |> ignore
            )

    [<EntryPoint>]
    let main argv =
        createHostBuilder(argv).Build().Run()
        0
