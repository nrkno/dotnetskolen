module Tests

open System
open System.IO
open System.Net
open Microsoft.AspNetCore.TestHost
open Microsoft.AspNetCore.Hosting
open Xunit
open NRK.Dotnetskolen.Api
open Json.Schema
open System.Text.Json

let createWebHostBuilder () =
    WebHostBuilder()
        .UseContentRoot(Directory.GetCurrentDirectory())
        .UseEnvironment("Test")
        .Configure(Program.configureApp)
        .ConfigureServices(Program.configureServices)

[<Fact>]
let ``Get EPG today returns 200 OK`` () =
    use testServer = new TestServer(createWebHostBuilder())
    use client = testServer.CreateClient()
    let todayAsString = DateTimeOffset.Now.ToString "yyyy-MM-dd"
    let url = sprintf "/epg/%s" todayAsString

    let response =
        client.GetAsync(url)
        |> Async.AwaitTask
        |> Async.RunSynchronously

    response.EnsureSuccessStatusCode()
    |> ignore

[<Fact>]
let ``Get EPG today returns valid response`` () =
    use testServer = new TestServer(createWebHostBuilder())
    use client = testServer.CreateClient()
    let todayAsString = DateTimeOffset.Now.ToString "yyyy-MM-dd"
    let url = sprintf "/epg/%s" todayAsString
    let jsonSchema = JsonSchema.FromFile "./epg.schema.json"

    let response =
        client.GetAsync(url)
        |> Async.AwaitTask
        |> Async.RunSynchronously

    response.EnsureSuccessStatusCode()
    |> ignore

    let bodyAsString =
        response.Content.ReadAsStringAsync()
        |> Async.AwaitTask
        |> Async.RunSynchronously

    let bodyAsJsonDocument = JsonDocument.Parse(bodyAsString).RootElement

    let isJsonValid =
        jsonSchema
            .Validate(bodyAsJsonDocument, ValidationOptions(RequireFormatValidation = true)).IsValid

    Assert.True(isJsonValid)

[<Fact>]
let ``Get EPG invalid date returns bad request`` () =
    use testServer = new TestServer(createWebHostBuilder())
    use client = testServer.CreateClient()
    let invalidDateAsString = "2021-13-32"
    let url = sprintf "/epg/%s" invalidDateAsString

    let response =
        client.GetAsync(url)
        |> Async.AwaitTask
        |> Async.RunSynchronously

    Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode)
