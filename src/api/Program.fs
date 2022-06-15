namespace NRK.Dotnetskolen.Api

module Program = 

    open Microsoft.AspNetCore.Builder

    [<EntryPoint>]
    let main argv =
        WebApplication.CreateBuilder(argv).Build().Run()
        0
