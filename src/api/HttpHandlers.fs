namespace NRK.Dotnetskolen.Api

module HttpHandlers =

    open System
    open System.Globalization
    open Microsoft.AspNetCore.Http
    open NRK.Dotnetskolen.Domain
    open NRK.Dotnetskolen.Dto

    let parseAsDateTime (dateAsString: string) : DateTime option =
        try
            let date = DateTime.ParseExact(dateAsString, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None)
            Some date
        with
        | _ -> None

    let epgHandler (getEpgForDate: DateTime -> Epg) (dateAsString: string) =
        match (parseAsDateTime dateAsString) with
        | Some date -> 
            let response =
                date
                |> getEpgForDate
                |> fromDomain
            Results.Ok(response)
        | None -> Results.BadRequest("Invalid date")
