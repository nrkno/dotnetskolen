namespace NRK.Dotnetskolen.Api

module HttpHandlers =

    open System
    open System.Globalization
    open Microsoft.AspNetCore.Http

    let parseAsDateTime (dateAsString : string) : DateTime option =
        try
            let date = DateTime.ParseExact(dateAsString, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None)
            Some date
        with
        | _ -> None

    let epgHandler date =
        match (parseAsDateTime date) with
        | Some parsedDate -> Results.Ok(parsedDate)
        | None -> Results.BadRequest("Invalid date")