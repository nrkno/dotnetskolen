namespace NRK.Dotnetskolen

module Domain = 

    open System
    open System.Text.RegularExpressions

    type Tittel = private Tittel of string
    type Kanal = private Kanal of string
    type Sendetidspunkt = private {
        StartTidspunkt: DateTimeOffset
        SluttTidspunkt: DateTimeOffset
    }

    let isTitleValid (title: string) : bool =
        let titleRegex = Regex(@"^[\p{L}0-9\.,-:!]{5,100}$")
        titleRegex.IsMatch(title)

    module Tittel =
        let create (tittel: String) : Tittel option = 
            if isTitleValid tittel then
                Tittel tittel
                |> Some
            else
                None

        let value (Tittel tittel) = tittel

    let isChannelValid (channel: string) : bool =
        List.contains channel ["NRK1"; "NRK2"]

    module Kanal =
        let create (kanal: string) : Kanal option =
            if isChannelValid kanal then
                Kanal kanal
                |> Some
            else
                None

        let value (Kanal kanal) = kanal

    let areStartAndEndTimesValid (startTime: DateTimeOffset) (endTime: DateTimeOffset) =
        startTime < endTime

    module Sendetidspunkt =
        let create (startTidspunkt: DateTimeOffset) (sluttTidspunkt: DateTimeOffset) : Sendetidspunkt option =
            if areStartAndEndTimesValid startTidspunkt sluttTidspunkt then
                {
                    StartTidspunkt = startTidspunkt
                    SluttTidspunkt = sluttTidspunkt
                }
                |> Some
            else
                None

        let startTidspunkt (sendeTidspunkt: Sendetidspunkt) = sendeTidspunkt.StartTidspunkt
        let sluttTidspunkt (sendeTidspunkt: Sendetidspunkt) = sendeTidspunkt.SluttTidspunkt

    type Sending = {
        Tittel: Tittel
        Kanal: Kanal
        Sendetidspunkt: Sendetidspunkt
    }

    type Epg = Sending list

    module Sending =
        let create (tittel: string) (kanal: string) (startTidspunkt: DateTimeOffset) (sluttTidspunkt: DateTimeOffset) : Sending option =
            let tittel = Tittel.create tittel
            let kanal = Kanal.create kanal
            let sendeTidspunkt = Sendetidspunkt.create startTidspunkt sluttTidspunkt

            if tittel.IsNone || kanal.IsNone || sendeTidspunkt.IsNone then
                None
            else
                Some {
                    Tittel = tittel.Value
                    Kanal = kanal.Value
                    Sendetidspunkt = sendeTidspunkt.Value
                }
