namespace NRK.Dotnetskolen.Api

module Services =
    open System
    open NRK.Dotnetskolen.Domain

    let getEpgForDate (getAllTransmissions : unit -> Epg) (date : DateTime) : Epg =
        getAllTransmissions ()
        |> List.filter (fun sending -> sending.StartTidspunkt.Date = date.Date)
