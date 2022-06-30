open System
open NRK.Dotnetskolen.Domain

let epg = [
    {
        Tittel = "Dagsrevyen"
        Kanal = "NRK1"
        Starttidspunkt = DateTimeOffset.Parse("2021-04-16T19:00:00+02:00")
        Sluttidspunkt = DateTimeOffset.Parse("2021-04-16T19:30:00+02:00")
    }
]
printfn "%A" epg
