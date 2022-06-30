module Tests

open System.Net.Http
open System.Threading.Tasks
open Xunit
open Microsoft.AspNetCore.TestHost
open NRK.Dotnetskolen.Api.Program

let runWithTestClient (test: HttpClient -> Task<unit>) = 
    task {
        let builder = createWebApplicationBuilder()
        builder.WebHost.UseTestServer() |> ignore

        use app = createWebApplication builder
        do! app.StartAsync()

        let testClient = app.GetTestClient()
        do! test testClient
    }

[<Fact>]
let ``Get "ping" returns "pong"`` () =
    runWithTestClient (fun httpClient -> 
        task {
            let! response = httpClient.GetStringAsync("ping")
            Assert.Equal(response, "pong")
        }
    )