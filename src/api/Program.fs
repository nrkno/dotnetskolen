namespace NRK.Dotnetskolen.Api

open System
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Http
open NRK.Dotnetskolen.Domain
open NRK.Dotnetskolen.Api.Services
open NRK.Dotnetskolen.Api.DataAccess
open NRK.Dotnetskolen.Api.HttpHandlers

module WebApplicationBuilder =
    let build (builder: WebApplicationBuilder) = builder.Build()

module WebApplication =
    let createBuilder () = WebApplication.CreateBuilder()

    let mapGet<'a> (pattern: string) (handler: HttpRequest -> 'a) (app: WebApplication) =
        app.MapGet(pattern, Func<HttpRequest, 'a>(handler)) |> ignore
        app

    let run (app: WebApplication) = app.Run()

module HttpRequest =
    let routeValue (key: string) (request: HttpRequest) =
        request.RouteValues[key]
        |> _.ToString()

module Program =
    let createWebApplication (getEpgForDate: DateOnly -> Epg) (app: WebApplication) =
        app
        |> WebApplication.mapGet "/ping" (fun _ -> "pong")
        |> WebApplication.mapGet "/epg/{date}" (HttpRequest.routeValue "date" >> epgHandler getEpgForDate)

    WebApplication.createBuilder()
    |> WebApplicationBuilder.build
    |> createWebApplication (getEpgForDate getAlleSendinger)
    |> WebApplication.run
