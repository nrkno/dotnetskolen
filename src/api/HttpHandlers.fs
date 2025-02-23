namespace NRK.Dotnetskolen.Api

module HttpHandlers =
    open System
    open System.Globalization
    open Microsoft.AspNetCore.Http

    let parseAsDate (dateAsString : string) : DateOnly option =
        try
            let date = DateOnly.ParseExact(dateAsString, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None)
            Some date
        with
        | _ -> None

    let epgHandler (dateAsString: string) =
        match parseAsDate dateAsString with
        | Some date -> Results.Ok date
        | None -> Results.BadRequest "Invalid date"