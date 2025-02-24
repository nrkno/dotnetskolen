namespace NRK.Dotnetskolen.Api

module Services =

    open System
    open NRK.Dotnetskolen.Domain

    let getEpgForDate (getAllTransmissions : unit -> Epg) (date : DateOnly) : Epg =
        getAllTransmissions()
        |> List.filter(fun t -> DateOnly.FromDateTime (AirTime.startTime t.AirTime).Date = date)
