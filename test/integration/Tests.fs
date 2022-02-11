module Tests

open Xunit
open Microsoft.AspNetCore.TestHost
open NRK.Dotnetskolen.Api.Program

[<Fact>]
let ``My test`` () =
    async {
        let builder = createBuilder([||])
        builder.WebHost.UseTestServer() |> ignore
        use app = createApp(builder)
        do! app.StartAsync() |> Async.AwaitTask
        let client = app.GetTestClient()
        let! helloWorld = client.GetStringAsync("/") |> Async.AwaitTask
        Assert.Equal(helloWorld, "Hello World!")
    }
