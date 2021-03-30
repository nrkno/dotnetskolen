module NRK.Dotnetskolen.Domain

open System
open System.Text.RegularExpressions

type Sending = {
    Id: string
    Tittel: string
    Medium: string
    Kanal: string
    StartTidspunkt: DateTimeOffset
    SluttTidspunkt: DateTimeOffset
}

type Epg = Sending list

let IsProgramIdValid (programId: string) : bool =
    let programIdRegex = Regex(@"^[a-zA-Z]{4}[0-9]{8}$")
    programIdRegex.IsMatch(programId)

let IsTitleValid (title: string) : bool =
    let titleRegex = Regex(@"^.{5,100}$")
    titleRegex.IsMatch(title)
