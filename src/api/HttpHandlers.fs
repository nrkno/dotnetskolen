module NRK.Dotnetskolen.Api.HttpHandlers

open System
open System.Globalization
open System.Threading.Tasks
open Microsoft.AspNetCore.Http
open Giraffe
open NRK.Dotnetskolen.Dto
open NRK.Dotnetskolen.Domain

let earlyReturn : HttpFunc = Some >> Task.FromResult

let isDateValid (dateAsString : string) (date : byref<DateTime>) : bool =
    DateTime.TryParseExact(dateAsString, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, &date)

let epgHandler (getEpgForDate : DateTime -> Epg) (dateAsString : string) : HttpHandler =
    fun (next : HttpFunc) (ctx : HttpContext) ->
        let mutable date = DateTime.MinValue
        if (isDateValid dateAsString &date) then
            let response = date
                            |> getEpgForDate 
                            |> fromDomain
                            |> json
            response next ctx
        else
            RequestErrors.badRequest (text "Invalid date") earlyReturn ctx

