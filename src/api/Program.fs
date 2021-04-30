namespace NRK.Dotnetskolen.Api

module Program =
    open System
    open NRK.Dotnetskolen.Domain

    open Microsoft.AspNetCore.Hosting
    open Microsoft.Extensions.DependencyInjection
    open Microsoft.AspNetCore.Builder

    let configureApp (webHostContext: WebHostBuilderContext) (app: IApplicationBuilder) =
        ()

    let configureServices (webHostContext: WebHostBuilderContext) (services: IServiceCollection) =
        ()

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
        0
