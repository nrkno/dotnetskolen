namespace NRK.Dotnetskolen.Api

module Services =

    open System
    open NRK.Dotnetskolen.Domain

    let getEpgForDate (getAlleSendinger : unit -> Epg) (date : DateTime) : Epg =
        getAlleSendinger ()
        |> List.filter (fun s -> (Sendetidspunkt.starttidspunkt s.Sendetidspunkt).Date.Date = date.Date)
