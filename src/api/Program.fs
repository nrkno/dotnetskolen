namespace NRK.Dotnetskolen.Api

module Program = 

    open System
    open Microsoft.AspNetCore.Builder

    let createWebApplicationBuilder (argv: string[]) =
        WebApplication.CreateBuilder(argv)

    let createWebApplication (builder: WebApplicationBuilder) =
        let app = builder.Build()
        app.MapGet("ping", Func<string>(fun () -> "pong")) |> ignore
        app

    [<EntryPoint>]
    let main argv =
        let builder = createWebApplicationBuilder argv
        let app = createWebApplication builder
        app.Run()
        0