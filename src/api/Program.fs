namespace NRK.Dotnetskolen.Api

module Program = 

    open System
    open Microsoft.AspNetCore.Builder

    let createWebApplicationBuilder () =
        WebApplication.CreateBuilder()

    let createWebApplication (builder: WebApplicationBuilder) =
        let app = builder.Build()
        app.MapGet("ping", Func<string>(fun () -> "pong")) |> ignore
        app

    let builder = createWebApplicationBuilder()
    let app = createWebApplication builder
    app.Run()