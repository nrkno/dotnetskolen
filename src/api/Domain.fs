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
        let channelRegex = Regex(@"^[A-Z1-2]{4,4}$")
        channelRegex.IsMatch(channel)

    let areStartAndEndTimesValid (startTime: DateTimeOffset) (endTime: DateTimeOffset) : bool =
      let ts = TimeSpan(1L)
      startTime < endTime && endTime - startTime > ts

    let isTransmissionValid (transmission: Sending) : bool =
      isTitleValid(transmission.Tittel) && isChannelValid(transmission.Kanal) && areStartAndEndTimesValid(transmission.StartTidspunkt)(transmission.SluttTidspunkt)
