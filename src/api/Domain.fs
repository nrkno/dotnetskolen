namespace NRK.Dotnetskolen

open System
open System.Text.RegularExpressions

module Domain = 

    open System

    type Sending = {
        Tittel: string
        Kanal: string
        Starttidspunkt: DateTimeOffset
        Sluttidspunkt: DateTimeOffset
    }

    type Epg = Sending list

    let isTittelValid (tittel: string) : bool =
        let tittelRegex = Regex(@"^[\p{L}0-9\.,-:!]{5,100}$")
        tittelRegex.IsMatch(tittel)

    let isKanalValid (kanal: string) : bool =
        List.contains kanal ["NRK1"; "NRK2"]

    let areStartAndSluttidspunktValid (starttidspunkt: DateTimeOffset) (sluttidspunkt: DateTimeOffset) =
        starttidspunkt < sluttidspunkt

    let isSendingValid (sending: Sending) : bool =
        (isTittelValid sending.Tittel) && 
        (isKanalValid sending.Kanal) && 
        (areStartAndSluttidspunktValid sending.Starttidspunkt sending.Sluttidspunkt)
