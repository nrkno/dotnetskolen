namespace NRK.Dotnetskolen.Api

module Program =

    open System
    open Microsoft.AspNetCore.Builder
    open NRK.Dotnetskolen.Api.HttpHandlers
    open Microsoft.AspNetCore.Http
    open NRK.Dotnetskolen.Api.Services
    open NRK.Dotnetskolen.Api.DataAccess
    open NRK.Dotnetskolen.Domain

    let createWebApplicationBuilder () =
        WebApplication.CreateBuilder()

    let createWebApplication (builder: WebApplicationBuilder) (getEpgForDate: DateOnly -> Epg) =
        let app = builder.Build()
        app.UseStaticFiles() |> ignore
        app.MapGet("/ping", Func<string>(fun () -> "pong")) |> ignore
        app.MapGet("/epg/{date}", Func<string, IResult>(fun date -> epgHandler getEpgForDate date)) |> ignore
        app

    let builder = createWebApplicationBuilder()
    let app = createWebApplication builder (getEpgForDate getAllTransmissions)
    app.Run()
