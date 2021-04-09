module Tests

open System
open Xunit
open Microsoft.AspNetCore.Mvc.Testing
open NRK.Dotnetskolen.Api.TestServer
open System.Net
open System.Text.Json
open Json.Schema

type public WebApiTests(factory: WebApplicationFactory<EntryPoint>) = 
    interface IClassFixture<WebApplicationFactory<EntryPoint>>

    member _.Factory = factory
     
    [<Fact>]
    member this.GetEpg_Today_Returns200OK () =
        // Arrange
        let client = this.Factory.CreateClient();
        let todayAsString = DateTimeOffset.Now.ToString "yyyy-MM-dd"
        let url = sprintf "/epg/%s" todayAsString

        // Act
        let response = client.GetAsync(url) |> Async.AwaitTask |> Async.RunSynchronously

        // Assert
        response.EnsureSuccessStatusCode() |> ignore
     
    [<Fact>]
    member this.GetEpg_Today_ReturnsValidResponse () =
        // Arrange
        let client = this.Factory.CreateClient();
        let todayAsString = DateTimeOffset.Now.ToString "yyyy-MM-dd"
        let url = sprintf "/epg/%s" todayAsString
        let jsonSchema = JsonSchema.FromFile "./epg.schema.json"

        // Act
        let response = client.GetAsync(url) |> Async.AwaitTask |> Async.RunSynchronously

        // Assert
        response.EnsureSuccessStatusCode() |> ignore
        let bodyAsString = response.Content.ReadAsStringAsync() |> Async.AwaitTask |> Async.RunSynchronously
        let bodyAsJsonDocument = JsonDocument.Parse(bodyAsString).RootElement
        let isJsonValid = jsonSchema.Validate(bodyAsJsonDocument, ValidationOptions(RequireFormatValidation = true)).IsValid
        
        Assert.True(isJsonValid)

    [<Fact>]
    member this.GetEpg_InvalidDate_ReturnsBadRequest () =
        // Arrange
        let client = this.Factory.CreateClient();
        let invalidDateAsString = "2021-13-32"
        let url = sprintf "/epg/%s" invalidDateAsString

        // Act
        let response = client.GetAsync(url) |> Async.AwaitTask |> Async.RunSynchronously

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode)
    