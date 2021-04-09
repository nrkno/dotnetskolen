open System
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
    let message = from "F#" // Call the function
    printfn "Hello world %s" message
    0 // return an integer exit code