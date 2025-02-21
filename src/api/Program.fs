open System
open NRK.Dotnetskolen.Domain

let epg = [
    {
        Title = "Dagsrevyen"
        Channel = "NRK1"
        StartTime = DateTimeOffset.Parse("2021-04-16T19:00:00+02:00")
        EndTime = DateTimeOffset.Parse("2021-04-16T19:30:00+02:00")
    }
]
printfn "%A" epg
