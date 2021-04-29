using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using Xunit;
using NRK.Dotnetskolen.Api;
using Json.Schema;
using System.Text.Json;


namespace NRK.Dotnetskolen.IntegrationTests
{
    public class IntegrationTests
    {
        public static IWebHostBuilder CreateWebHostBuilder() =>
            new WebHostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseEnvironment("Test")
                .Configure(Program.ConfigureApp)
                .ConfigureServices(Program.ConfigureServices);

        [Fact]
        public async Task GetEPGToday_Returns200OK()
        {
            TestServer testServer = new (CreateWebHostBuilder());

            HttpClient client = testServer.CreateClient();
            string todayAsString = DateTimeOffset.Now.ToString("yyyy-MM-dd");
            string url = $"/epg/{todayAsString}";

            HttpResponseMessage response = await client.GetAsync(url);
            HttpResponseMessage httpResponseMessage = response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetEPGToday_returnValidResponse()
        {
            TestServer testServer = new (CreateWebHostBuilder());
            HttpClient client = testServer.CreateClient();
            string todayAsString = DateTimeOffset.Now.ToString("yyyy-MM-dd");
            string url = $"/epg/{todayAsString}";
            JsonSchema jsonSchema = JsonSchema.FromFile("./epg.schema.json");

            HttpResponseMessage response = await client.GetAsync(url);
            HttpResponseMessage httpResponseMessage = response.EnsureSuccessStatusCode();

            string bodyAsString = await response.Content.ReadAsStringAsync();
            JsonElement bodyAsJsonDocument = JsonDocument.Parse(bodyAsString).RootElement;
            bool isJsonValid = jsonSchema.Validate(bodyAsJsonDocument, new ValidationOptions { RequireFormatValidation = true }).IsValid;

            Assert.True(isJsonValid);
        }

        [Fact]
        public async Task GetEPG_InvalidDate_ReturnsBadRequest()
        {
            TestServer testServer = new (CreateWebHostBuilder());
            HttpClient client = testServer.CreateClient();
            const string invalidDateAsString = "2021-13-32";
            string url = $"/epg/{invalidDateAsString}";

            HttpResponseMessage response = await client.GetAsync(url);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}