open System
open NRK.Dotnetskolen.Domain
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.DependencyInjection
open Microsoft.AspNetCore.Builder

let configureApp (webHostContext: WebHostBuilderContext) (app: IApplicationBuilder) =
    ()

let configureServices (webHostContext: WebHostBuilderContext) (services: IServiceCollection) =
    ()

let CreateHostBuilder args =
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(fun webBuilder -> 
            webBuilder
                .Configure(configureApp)
                .ConfigureServices(configureServices)
            |> ignore
        )

// Define a function to construct a message to print
let from whom =
    sprintf "from %s" whom

[<EntryPoint>]
let main argv =
    let epg = [
        {
            Tittel = "Dagsrevyen"
            Kanal = "NRK1"
            StartTidspunkt = DateTimeOffset.Parse("2021-04-16T19:00:00+02:00")
            SluttTidspunkt = DateTimeOffset.Parse("2021-04-16T19:30:00+02:00")
        }
    ]
    printfn "%A" epg
    0 // return an integer exit code