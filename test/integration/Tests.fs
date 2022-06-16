module Tests

open System
open System.Net
open System.Net.Http
open System.Text.Json
open Xunit
open Json.Schema
open Microsoft.AspNetCore.TestHost
open NRK.Dotnetskolen.Api.Program
open NRK.Dotnetskolen.Api.Services
open NRK.Dotnetskolen.IntegrationTests.Mock

let runWithTestClient (test: HttpClient -> Async<unit>) = 
    async {
        let builder = createWebApplicationBuilder()
        builder.WebHost.UseTestServer() |> ignore

        use app = createWebApplication builder (getEpgForDate getAllTransmissions)
        do! app.StartAsync() |> Async.AwaitTask

        let testClient = app.GetTestClient()
        do! test testClient
    } |> Async.RunSynchronously

[<Fact>]
let ``Get "ping" returns "pong"`` () =
    runWithTestClient (fun httpClient -> 
        async {
            let! response = httpClient.GetStringAsync("/ping") |> Async.AwaitTask
            Assert.Equal(response, "pong")
        }
    )

[<Fact>]
let ``Get EPG today returns 200 OK`` () =
    runWithTestClient (fun httpClient -> 
        async {
            let todayAsString = DateTimeOffset.Now.ToString "yyyy-MM-dd"
            let url = $"/epg/{todayAsString}" 
            let! response = httpClient.GetAsync(url) |> Async.AwaitTask
            response.EnsureSuccessStatusCode() |> ignore
        }
    )

[<Fact>]
let ``Get EPG invalid date returns bad request`` () =
    runWithTestClient (fun httpClient -> 
        async {
            let invalidDateAsString = "2021-13-32"
            let url = $"/epg/{invalidDateAsString}"
            let! response = httpClient.GetAsync(url) |> Async.AwaitTask
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode)
        }
    )

[<Fact>]
let ``Get EPG today return valid response`` () =
    runWithTestClient (fun httpClient -> 
        async {
            let todayAsString = DateTimeOffset.Now.ToString "yyyy-MM-dd"
            let url = $"/epg/{todayAsString}"
            let jsonSchema = JsonSchema.FromFile "./epg.schema.json"

            let! response = httpClient.GetAsync(url) |> Async.AwaitTask

            response.EnsureSuccessStatusCode() |> ignore
            let! bodyAsString = response.Content.ReadAsStringAsync() |> Async.AwaitTask
            let bodyAsJsonDocument = JsonDocument.Parse(bodyAsString).RootElement
            let isJsonValid = jsonSchema.Validate(bodyAsJsonDocument, ValidationOptions(RequireFormatValidation = true)).IsValid
            
            Assert.True(isJsonValid)
        }
    )
