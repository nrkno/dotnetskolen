// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open NRK.Dotnetskolen.Domain

// Define a function to construct a message to print
let from whom =
    sprintf "from %s" whom

[<EntryPoint>]
let main argv =
    let epg = [
        {
            Tittel = "Dagsrevyen"
            Kanal = "NRK1"
            StartTidspunkt = DateTimeOffset.Parse("2021-04-16T19:00:00+02:00")
            SluttTidspunkt = DateTimeOffset.Parse("2021-04-16T19:30:00+02:00")
        }
    ]
    printfn "%A" epg
    0 // return an integer exit code