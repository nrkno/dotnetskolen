namespace NRK.Dotnetskolen.Api

module Services =

    open System
    open NRK.Dotnetskolen.Domain

    let getEpgForDate (getAlleSendinger : unit -> Epg) (date : DateTimeOffset) : Epg =
        getAlleSendinger ()
        |> List.filter (fun s -> s.Starttidspunkt = date)