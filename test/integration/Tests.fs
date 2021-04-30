module Tests

open System
open System.IO
open System.Net
open System.Text.Json
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.TestHost
open Xunit
open Json.Schema
open NRK.Dotnetskolen.Api
open NRK.Dotnetskolen.Api.Services
open NRK.Dotnetskolen.IntegrationTests.Mock

let createWebHostBuilder () =
    WebHostBuilder()
        .UseContentRoot(Directory.GetCurrentDirectory()) 
        .UseEnvironment("Test")
        .Configure(Program.configureApp (getEpgForDate getAllTransmissions))
        .ConfigureServices(Program.configureServices)

[<Fact>]
let ``Get EPG today returns 200 OK`` () = async {
    use testServer = new TestServer(createWebHostBuilder())
    use client = testServer.CreateClient()
    let todayAsString = DateTimeOffset.Now.ToString "yyyy-MM-dd"
    let url = sprintf "/epg/%s" todayAsString

    let! response = client.GetAsync(url) |> Async.AwaitTask

    response.EnsureSuccessStatusCode() |> ignore
}
    
[<Fact>]
let ``Get EPG today return valid response`` () = async {
    use testServer = new TestServer(createWebHostBuilder())
    use client = testServer.CreateClient()
    let todayAsString = DateTimeOffset.Now.ToString "yyyy-MM-dd"
    let url = sprintf "/epg/%s" todayAsString
    let jsonSchema = JsonSchema.FromFile "./epg.schema.json"

    let! response = client.GetAsync(url) |> Async.AwaitTask

    response.EnsureSuccessStatusCode() |> ignore
    let! bodyAsString = response.Content.ReadAsStringAsync() |> Async.AwaitTask
    let bodyAsJsonDocument = JsonDocument.Parse(bodyAsString).RootElement
    let isJsonValid = jsonSchema.Validate(bodyAsJsonDocument, ValidationOptions(RequireFormatValidation = true)).IsValid
    
    Assert.True(isJsonValid)
}

[<Fact>]
let ``Get EPG invalid date returns bad request`` () = async {
    use testServer = new TestServer(createWebHostBuilder())
    use client = testServer.CreateClient()
    let invalidDateAsString = "2021-13-32"
    let url = sprintf "/epg/%s" invalidDateAsString

    let! response = client.GetAsync(url) |> Async.AwaitTask

    Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode)
}
