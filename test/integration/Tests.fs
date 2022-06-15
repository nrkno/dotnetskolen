module Tests

open System.Net.Http
open Xunit
open Microsoft.AspNetCore.TestHost
open NRK.Dotnetskolen.Api.Program

let runWithTestClient (test: HttpClient -> Async<unit>) = 
    async {
        let builder = createBuilder([||])
        builder.WebHost.UseTestServer() |> ignore

        use app = createApp builder
        do! app.StartAsync() |> Async.AwaitTask

        let client = app.GetTestClient()
        do! test client
    } |> Async.RunSynchronously

[<Fact>]
let ``A request to "/" returns "Hello World!"`` () =
    runWithTestClient (fun httpClient -> 
        async {
            let! helloWorld = httpClient.GetStringAsync("/") |> Async.AwaitTask
            Assert.Equal(helloWorld, "Hello World!")
        }
    )
