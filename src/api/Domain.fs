module NRK.Dotnetskolen.Domain

open System

type Sending = {
    Id: string
    Tittel: string
    Medium: string
    Kanal: string
    StartTidspunkt: DateTimeOffset
    SluttTidspunkt: DateTimeOffset
}

type Epg = Sending list
