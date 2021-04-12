module NRK.Dotnetskolen.IntegrationTests.CustomWebApplicationFactory

open System
open System.Linq
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.Mvc.Testing
open Microsoft.Extensions.DependencyInjection
open NRK.Dotnetskolen.Domain
open NRK.Dotnetskolen.Api.Services
open NRK.Dotnetskolen.IntegrationTests.Mock

type public CustomWebApplicationFactory<'TStartup when 'TStartup : not struct>() =
    inherit WebApplicationFactory<'TStartup>()
    override _.ConfigureWebHost (webHostBuilder: IWebHostBuilder) =
        webHostBuilder.ConfigureServices(fun (serviceCollection: IServiceCollection) ->
            let existingGetEpgForDateFunction = serviceCollection.SingleOrDefault((fun s -> s.ServiceType = typeof<DateTime -> Epg>))
            serviceCollection.Remove(existingGetEpgForDateFunction) |> ignore
            
            serviceCollection.AddSingleton<DateTime -> Epg>(getEpgForDate getAllTransmissions) |> ignore
            ()
        ) |> ignore