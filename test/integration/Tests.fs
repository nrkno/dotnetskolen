module Tests

open System.Net.Http
open Xunit
open Microsoft.AspNetCore.TestHost
open NRK.Dotnetskolen.Api.Program

let runWithTestClient (test: HttpClient -> Async<unit>) = 
    async {
        let builder = createWebApplicationBuilder()
        builder.WebHost.UseTestServer() |> ignore

        use app = createWebApplication builder
        do! app.StartAsync() |> Async.AwaitTask

        let testClient = app.GetTestClient()
        do! test testClient
    } |> Async.RunSynchronously

[<Fact>]
let ``Get "ping" returns "pong"`` () =
    runWithTestClient (fun httpClient -> 
        async {
            let! response = httpClient.GetStringAsync("ping") |> Async.AwaitTask
            Assert.Equal(response, "pong")
        }
    )
