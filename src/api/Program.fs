namespace NRK.Dotnetskolen.Api

module Program = 

    open System
    open Microsoft.AspNetCore.Builder

    let createBuilder (argv: string []) =
        let builder = WebApplication.CreateBuilder(argv)
        // Do stuff with builder here
        builder

    let createApp (builder: WebApplicationBuilder) =
        let app = builder.Build()
        app.MapGet("/", Func<string>(fun () -> "Hello World!")) |> ignore
        app

    [<EntryPoint>]
    let main argv =
        let builder = createBuilder argv
        let app = createApp builder
        app.Run()
        0
