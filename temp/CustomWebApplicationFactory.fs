module NRK.Dotnetskolen.IntegrationTests.CustomWebApplicationFactory

open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.Mvc.Testing
open Microsoft.Extensions.DependencyInjection

type public CustomWebApplicationFactory<'TStartup when 'TStartup : not struct>() =
    inherit WebApplicationFactory<'TStartup>()
    override _.ConfigureWebHost (webHostBuilder: IWebHostBuilder) =
        webHostBuilder.ConfigureServices(fun (serviceCollection: IServiceCollection) ->
            ()
        ) |> ignore