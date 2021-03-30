open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Hosting
open NRK.Dotnetskolen.Api.Startup

let exitCode = 0

let CreateHostBuilder args =
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(fun webBuilder ->
            webBuilder.UseStartup<Startup>() |> ignore
        )

[<EntryPoint>]
let main args =
    CreateHostBuilder(args).Build().Run()

    exitCode