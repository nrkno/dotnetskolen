module NRK.Dotnetskolen.Domain

open System

type Kanal =
    | NRK1
    | NRK2
    | NRK3
    | NRKSUPER

type EpgInnslag = {
    Id: string
    Tittel: string
    Kanal: Kanal
    StartTidspunkt: DateTimeOffset
    SluttTidspunkt: DateTimeOffset
}

type Epg = EpgInnslag list