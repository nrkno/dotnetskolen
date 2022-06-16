## Dependenjy injection

Vi ser nærmere på hva man kan bruke som "composition root" i .NET i [avsnittet om å implemetere avhengighetene til API-et vårt i steg 10](#implementere-avhengigheter).

For å konfigurere depdenency injection, og sette opp en "composition root", i ASP.NET-applikasjoner bruker man funksjonen `ConfigureServices` i `IWebHostBuilder`-objektet. Utvid `Program.fs` i API-prosjektet med følgende `open`-statement, funksjonen `configureServices`, og et kall til `configureServices` i `ConfigureWebHostDefaults`, slik:

```f#
...
open Microsoft.Extensions.DependencyInjection
...
let configureServices (webHostContext: WebHostBuilderContext) (services: IServiceCollection) =
    ()

let createHostBuilder args =
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(fun webHostBuilder ->
            webHostBuilder
                .Configure(configureApp)
                .ConfigureServices(configureServices) |> ignore
        )
...
```

###### Kjøre webhost

Hvis du kjører API-et nå, vil du ikke se noen forskjell fra sist ettersom vi ikke har lagt til noen tjenester i `configureServices`. Det gjør vi imidlertid noe med i neste avsnitt.

```bash
$ dotnet run --project ./src/api/NRK.Dotnetskolen.Api.fsproj
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: http://localhost:5000
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: https://localhost:5001
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Production
info: Microsoft.Hosting.Lifetime[0]
      Content root path: C:\Dev\nrkno@github.com\dotnetskolen\src\api
```

##### Sende inn `getEpgForDate` til `epgHandler`

Utvid deretter `configureApp`-funksjonen til å ta inn et parameter `getEpgForDate` og send det inn til `epgHandler`, slik:

```f#
let configureApp (getEpgForDate: DateTime -> Epg) (webHostContext: WebHostBuilderContext) (app: IApplicationBuilder) =
    let webApp =
        GET >=> choose [
                route "/ping" >=> text "pong"
                routef "/epg/%s" (epgHandler getEpgForDate)
        ]
    app.UseGiraffe webApp
```

Til slutt må vi utvide `createHostBuilder`-funksjonen til å sende inn implementasjonen av `getEpgForDate` til `configureApp`, slik:

```f#
let createHostBuilder args =
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(fun webBuilder -> 
            webBuilder
                .Configure(configureApp getEpgForDate)
                .ConfigureServices(configureServices)
            |> ignore
        )
```

##### Fikse tester

Ettersom vi har innført `getEpgForDate` som parameter til `configureApp`-funksjonen, må vi sende inn det parameteret når vi lager `IWebHostBuilder` i `createWebHostBuilder`-funksjonen i `Tests.fs` i integrasjonstestprosjektet. Legg til følgende `open`-statements, og utvid `createWebHostBuilder`-funksjonen slik:

```f#
...
open NRK.Dotnetskolen.Api.DataAccess
open NRK.Dotnetskolen.Api.Services
...
let createWebHostBuilder () =
    WebHostBuilder()
        .UseContentRoot(Directory.GetCurrentDirectory()) 
        .UseEnvironment("Test")
        .Configure(Program.configureApp (getEpgForDate getAllTransmissions))
        .ConfigureServices(Program.configureServices)
```

Kjør testene på nytt med følgende kommando, og se om alle testene passerer nå:

```bash
$ dotnet test test/integration/NRK.Dotnetskolen.IntegrationTests.fsproj

Passed!  - Failed:     0, Passed:     4, Skipped:     0, Total:     4, Duration: 214 ms - NRK.Dotnetskolen.IntegrationTests.dll (net5.0)
```
