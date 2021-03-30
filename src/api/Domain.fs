module NRK.Dotnetskolen.Domain

open System
open System.Text.RegularExpressions

type Sending = {
    Tittel: string
    Kanal: string
    StartTidspunkt: DateTimeOffset
    SluttTidspunkt: DateTimeOffset
}

type Epg = Sending list

let IsTitleValid (title: string) : bool =
    let titleRegex = Regex(@"^.{5,100}$")
    titleRegex.IsMatch(title)
