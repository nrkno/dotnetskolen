module Tests

open System
open System.Net
open System.Net.Http
open System.Text.Json
open System.Threading.Tasks
open Xunit
open Json.Schema
open Microsoft.AspNetCore.TestHost
open NRK.Dotnetskolen.Api
open NRK.Dotnetskolen.Api.Program
open NRK.Dotnetskolen.Api.Services
open NRK.Dotnetskolen.IntegrationTests.Mock

let runWithTestClient (test: HttpClient -> Task<unit>) =
    task {
        let builder = WebApplication.createBuilder()
        builder.WebHost.UseTestServer() |> ignore

        use app =
            builder
            |> WebApplicationBuilder.build
            |> createWebApplication (getEpgForDate getAlleSendinger)
        do! app.StartAsync()

        let testClient = app.GetTestClient()
        do! test testClient
    }

[<Fact>]
let ``Get "ping" returns "pong"`` () =
    runWithTestClient (fun httpClient ->
        task {
            let! response = httpClient.GetStringAsync("/ping")
            Assert.Equal(response, "pong")
        }
    )

[<Fact>]
let ``Get EPG today returns 200 OK`` () =
    runWithTestClient (fun httpClient ->
        task {
            let todayAsString = DateTimeOffset.Now.ToString "yyyy-MM-dd"
            let url = $"/epg/{todayAsString}"
            let! response = httpClient.GetAsync(url)
            response.EnsureSuccessStatusCode() |> ignore
        }
    )

[<Fact>]
let ``Get EPG invalid date returns bad request`` () =
    runWithTestClient (fun httpClient ->
        task {
            let invalidDateAsString = "2021-13-32"
            let url = $"/epg/{invalidDateAsString}"
            let! response = httpClient.GetAsync(url)
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode)
        }
    )

[<Fact>]
let ``Get EPG today return valid response`` () =
    runWithTestClient (fun httpClient ->
        task {
            let todayAsString = DateTimeOffset.Now.ToString "yyyy-MM-dd"
            let url = $"/epg/{todayAsString}"
            let jsonSchema = JsonSchema.FromFile "./epg.schema.json"

            let! response = httpClient.GetAsync(url)

            response.EnsureSuccessStatusCode() |> ignore
            let! bodyAsString = response.Content.ReadAsStringAsync()
            let bodyAsJsonDocument = JsonDocument.Parse(bodyAsString).RootElement
            let isJsonValid = jsonSchema.Evaluate(bodyAsJsonDocument, EvaluationOptions(RequireFormatValidation = true)).IsValid

            Assert.True(isJsonValid)
        }
    )
