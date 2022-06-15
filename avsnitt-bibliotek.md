##### Dependency injection

Et mye brukt prinsipp i programvareutvikling er "Inversion of control" (IoC), som kort fortalt går ut på at man lar kontrollen over implementasjonen av avhengighetene man har i koden sin ligge på utsiden av der man har behov for avhengigheten. På denne måten kan man endre hva som implementerer avhengigheten man har, og man kan enklere enhetsteste koden sin fordi man kan sende inn fiktive implementasjoner av avhengighetene.

Et eksempel på dette er dersom man har en funksjon `isLoginValid` for å validere brukernavn og passord som kommer inn fra et innloggingsskjema, har man behov for å hente entiteten som korresponderer til det oppgitte brukernavnet fra brukerdatabasen. Ved å ta inn en egen funksjon `getUser` i `ValidateLogin` har man gitt kontrollen over hvordan `getUser` skal implementeres til utsiden av `ValidateLogin`-funksjonen.

```f#
let isLoginValid (getUser: string -> UserEntity) (username: string) (password: string) : bool ->
...
```

En måte å oppnå IoC på er å bruke "dependency injection" (DI). Da sender man inn de nødvendige avhengighetene til de ulike delene av koden sin fra utsiden. Dersom en funksjon `A` har avhengiheter funksjonene `B` og `C`, og `B` og `C` har hhv. avhengiheter til funksjonene `D` og `E`, må man ha implementasjoner for `B`, `C`, `D` og `E` for å kunne kalle funksjon `A`. Disse avhengighetene danner et avhengighetstre, og dersom man skal kalle en funksjon på toppen av treet er man nødt til å ha implementasjoner av alle de interne nodene og alle løvnodene i avhengighetstreet. For hver toppnivåfunksjon (slik som `A`) man har i applikasjonen sin, vil man ha et avhengighetstre.

Den delen av applikasjonen som har ansvar for å tilfredsstille alle avhengighetene til alle toppnivåfunksjoner i applikasjonen kalles "composition root". Vi ser nærmere på hva man kan bruke som "composition root" i .NET i [avsnittet om å implemetere avhengighetene til API-et vårt i steg 10](#implementere-avhengigheter).

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

> Du kan lese mer om "dependency injection" her: [https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-6.0](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-6.0)

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
