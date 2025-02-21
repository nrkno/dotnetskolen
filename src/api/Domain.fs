namespace NRK.Dotnetskolen

module Domain =

    open System
    open System.Text.RegularExpressions

    type Transmission = {
        Title: string
        Channel: string
        StartTime: DateTimeOffset
        EndTime: DateTimeOffset
    }

    type Epg = Transmission list

    let isTitleValid (title: string) : bool =
        let titleRegex = Regex(@"^[\p{L}0-9\.,-:!]{5,100}$")
        titleRegex.IsMatch(title)

    let isChannelValid (channel: string) : bool = 
        List.contains channel ["NRK1"; "NRK2"]

    let areStartTimeAndEndTimeValid (startTime: DateTimeOffset) (endTime: DateTimeOffset) =
        startTime < endTime

    let isTransmissionValid (transmission: Transmission) : bool =
        isTitleValid transmission.Title
        && isChannelValid transmission.Channel 
        && areStartTimeAndEndTimeValid transmission.StartTime transmission.EndTime
