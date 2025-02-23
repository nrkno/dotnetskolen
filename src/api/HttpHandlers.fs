namespace NRK.Dotnetskolen.Api

module HttpHandlers =
    open System
    open System.Globalization
    open Microsoft.AspNetCore.Http
    open NRK.Dotnetskolen.Domain
    open NRK.Dotnetskolen.Dto

    let parseAsDate (dateAsString : string) : DateOnly option =
        try
            let date = DateOnly.ParseExact(dateAsString, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None)
            Some date
        with
        | _ -> None

    let epgHandler (getEpgForDate: DateOnly -> Epg) (dateAsString: string) =
        match parseAsDate dateAsString with
        | Some date ->
            let response = 
                date
                |> getEpgForDate
                |> fromDomain
            Results.Ok response
        | None -> Results.BadRequest "Invalid date"