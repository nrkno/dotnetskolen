namespace NRK.Dotnetskolen

open System
open System.Text.RegularExpressions

module Domain = 

    open System

    type Sending = {
        Tittel: string
        Kanal: string
        StartTidspunkt: DateTimeOffset
        SluttTidspunkt: DateTimeOffset
    }

    type Epg = Sending list

    let isTitleValid (title: string) : bool =
        let titleRegex = Regex(@"^[\p{L}0-9\.,-:!]{5,100}$")
        titleRegex.IsMatch(title)

    let isChannelValid (channel: string) : bool =
        List.contains channel ["NRK1"; "NRK2"]

    let areStartAndEndTimesValid (startTime: DateTimeOffset) (endTime: DateTimeOffset) =
        startTime < endTime

    let isTransmissionValid (transmission: Sending) : bool =
        (isTitleValid transmission.Tittel) && 
        (isChannelValid transmission.Kanal) && 
        (areStartAndEndTimesValid transmission.StartTidspunkt transmission.SluttTidspunkt)
