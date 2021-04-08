module NRK.Dotnetskolen.Dto

open System

type Sending = {
    Tittel: string
    Kanal: string
    StartTidspunkt: string
    SluttTidspunkt: string
}

type Epg = Sending list