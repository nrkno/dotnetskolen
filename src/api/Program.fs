namespace NRK.Dotnetskolen.Api

module Program = 

    open System
    open Microsoft.AspNetCore.Http
    open Microsoft.AspNetCore.Builder
    open NRK.Dotnetskolen.Api.HttpHandlers

    let createWebApplicationBuilder () =
        WebApplication.CreateBuilder()

    let createWebApplication (builder: WebApplicationBuilder) =
        let app = builder.Build()
        app.MapGet("/ping", Func<string>(fun () -> "pong")) |> ignore
        app.MapGet("/epg/{date}", Func<string, IResult>(fun date -> epgHandler date)) |> ignore
        app

    let builder = createWebApplicationBuilder()
    let app = createWebApplication builder
    app.Run()