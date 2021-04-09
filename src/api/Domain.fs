module NRK.Dotnetskolen.Domain

open System

type Sending = {
    Tittel: string
    Kanal: string
    StartTidspunkt: DateTimeOffset
    SluttTidspunkt: DateTimeOffset
}

type Epg = Sending list
