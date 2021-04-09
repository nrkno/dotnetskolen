module NRK.Dotnetskolen.Domain

open System
open System.Text.RegularExpressions

type Sending = {
    Tittel: string
    Kanal: string
    StartTidspunkt: DateTime
    SluttTidspunkt: DateTime
}

type Epg = Sending list

let IsTitleValid (title: string) : bool =
    let titleRegex = Regex(@"^[\p{L}0-9\.,-:!]{5,100}$")
    titleRegex.IsMatch(title)

let IsChannelValid (channel: string) : bool =
    List.contains channel ["NRK1"; "NRK2"]

let AreStartAndEndTimesValid (startTime: DateTime) (endTime: DateTime) =
    startTime < endTime

let IsTransmissionValid (transmission: Sending) : bool =
    (IsTitleValid transmission.Tittel) && 
    (IsChannelValid transmission.Kanal) && 
    (AreStartAndEndTimesValid transmission.StartTidspunkt transmission.SluttTidspunkt)
