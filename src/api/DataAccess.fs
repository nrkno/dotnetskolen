module NRK.Dotnetskolen.Api.DataAccess

open System
open NRK.Dotnetskolen.Domain

let dataStore = 
    [
        {
            Tittel = "Testprogram"
            Kanal = "NRK1"
            StartTidspunkt = DateTimeOffset.Now
            SluttTidspunkt = DateTimeOffset.Now.AddMinutes(30.)
        }
        {
            Tittel = "Testprogram"
            Kanal = "NRK2"
            StartTidspunkt = DateTimeOffset.Now
            SluttTidspunkt = DateTimeOffset.Now.AddMinutes(30.)
        }
        {
            Tittel = "Testprogram"
            Kanal = "NRK3"
            StartTidspunkt = DateTimeOffset.Now
            SluttTidspunkt = DateTimeOffset.Now.AddMinutes(30.)
        }
    ]

let getAllTransmissions () : Epg =
    dataStore
    |> List.filter (fun s -> IsTransmissionValid s)