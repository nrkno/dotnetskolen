using System;
using NRK.Dotnetskolen.Api.Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;


namespace NRK.Dotnetskolen.Api
{
    public class Program
    {
        public static void ConfigureApp(IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //app.Map("/ping", map => map.Run(async ctx => await ctx.Response.WriteAsync("pong")));
            ////app.Map("/epg/{date}", map => map.
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMvc();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .Configure(ConfigureApp)
                        .ConfigureServices(ConfigureServices);
                });

        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            Epg epg = new() {
                Sendinger = new ()
                {
                    new Sending {
                        Tittel = "Dagsrevyen",
                        Kanal = "NRK1",
                        StartTidspunkt = DateTimeOffset.Parse("2021-04-16T19:00:00+02:00"),
                        SluttTidspunkt = DateTimeOffset.Parse("2021-04-16T19:30:00+02:00")
                    }
                }
            };

            foreach(Sending sending in epg.Sendinger)
                Console.WriteLine(sending.Tittel);
        }
    }
}