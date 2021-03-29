module NRK.Dotnetskolen.Domain

open System
open System.Text.RegularExpressions

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

let IsProgramIdValid (programId: string) : bool =
    let programIdRegex = Regex(@"^[a-zA-Z]{4}[0-9]{8}$")
    programIdRegex.IsMatch(programId)

let IsTitleValid (title: string) : bool =
    let titleRegex = Regex(@"^.{5,100}$")
    titleRegex.IsMatch(title)