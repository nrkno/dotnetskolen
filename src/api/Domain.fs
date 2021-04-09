module NRK.Dotnetskolen.Domain

open System

type Sending = {
    Tittel: string
    Kanal: string
    StartTidspunkt: DateTime
    SluttTidspunkt: DateTime
}

type Epg = Sending list
