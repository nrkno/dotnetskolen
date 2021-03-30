module Tests

open System
open System.Net
open Xunit
open NRK.Dotnetskolen.Api.Startup
open NRK.Dotnetskolen.IntegrationTests.CustomWebApplicationFactory

type public WebApiTests(factory: CustomWebApplicationFactory<Startup>) = 
    member _.Factory = factory
     
    [<Fact>]
    member this.GetEpg_NRK1Today_ReturnsValidEpgResponse () =
        // Arrange
        let client = this.Factory.CreateClient();
        let todayAsString = DateTimeOffset.Now.ToString "yyyy-MM-dd"
        let url = sprintf "/epg/NRK1/%s" todayAsString

        // Act
        let response = client.GetAsync(url) |> Async.AwaitTask |> Async.RunSynchronously

        // Assert
        response.EnsureSuccessStatusCode() |> ignore

    [<Fact>]
    member this.GetEpg_NRK3Today_ReturnsBadRequest () =
        // Arrange
        let client = this.Factory.CreateClient();
        let todayAsString = DateTimeOffset.Now.ToString "yyyy-MM-dd"
        let url = sprintf "/epg/NRK3/%s" todayAsString

        // Act
        let response = client.GetAsync(url) |> Async.AwaitTask |> Async.RunSynchronously

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode)
    
    interface IClassFixture<CustomWebApplicationFactory<Startup>>