namespace NRK.Dotnetskolen.Api

module Services =

    open System
    open NRK.Dotnetskolen.Domain

    let getEpgForDate (getAlleSendinger : unit -> Epg) (date : DateOnly) : Epg =
        getAlleSendinger ()
        |> List.filter (fun s -> DateOnly.FromDateTime(s.Starttidspunkt.Date) = date)