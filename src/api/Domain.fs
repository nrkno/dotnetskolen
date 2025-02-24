namespace NRK.Dotnetskolen

module Domain =

    open System
    open System.Text.RegularExpressions

    type Title = private Title of string

    let isTitleValid (title: string) : bool =
        let titleRegex = Regex(@"^[\p{L}0-9\.,-:!]{5,100}$")
        titleRegex.IsMatch(title)

    module Title =
        let create (title: String) : Title option =
            if isTitleValid title then
                Title title
                |> Some
            else
                None

        let value(Title title) = title

    type Channel = private Channel of string

    let isChannelValid (channel: string) : bool =
        List.contains channel ["NRK1"; "NRK2"]

    module Channel =
        let create (channel: string) : Channel option =
            if isChannelValid channel then
                Channel channel
                |> Some
            else
                None

        let value (Channel channel) = channel

    type AirTime = private {
        StartTime: DateTimeOffset
        EndTime: DateTimeOffset
    }

    let areStartTimeAndEndTimeValid (startTime: DateTimeOffset) (endTime: DateTimeOffset) =
        startTime < endTime

    module AirTime =
        let create (startTime: DateTimeOffset) (endTime: DateTimeOffset) : AirTime option =
            if areStartTimeAndEndTimeValid startTime endTime then
                {
                    StartTime = startTime
                    EndTime = endTime
                }
                |> Some
            else
                None

        let startTime (airTime: AirTime) = airTime.StartTime
        let endTime (airTime: AirTime) = airTime.EndTime

    type Transmission = {
        Title: Title
        Channel: Channel
        AirTime: AirTime
    }

    type Epg = Transmission list

    module Transmission =
        let create (title: string) (channel: string) (startTime: DateTimeOffset) (endTime: DateTimeOffset) : Transmission option =
            let title = Title.create title
            let channel = Channel.create channel
            let airTime = AirTime.create startTime endTime

            if title.IsNone || channel.IsNone || airTime.IsNone then
                None
            else
                Some {
                    Title = title.Value
                    Channel = channel.Value
                    AirTime = airTime.Value
                }
