namespace NRK.Dotnetskolen

module Domain =
    open System
    open System.Text.RegularExpressions

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
        match channel with
        | "NRK1"
        | "NRK2" -> true
        | _ -> false


    let areStartAndEndTimesValid (startTime: DateTimeOffset) (endTime: DateTimeOffset) =
        startTime < endTime

    let isTransmissionValid (transmission: Sending) : bool =
        let isTitleValid = isTitleValid transmission.Tittel
        let isChannelValid = isChannelValid transmission.Kanal

        let areStartAndEndTimesValid =
            areStartAndEndTimesValid transmission.StartTidspunkt transmission.SluttTidspunkt

        match isTitleValid, isChannelValid, areStartAndEndTimesValid with
        | true, true, true -> true
        | _ -> false
