namespace NRK.Dotnetskolen

module Domain = 

    open System
    open System.Text.RegularExpressions

    type Tittel = private Tittel of string

    let isTittelValid (tittel: string) : bool =
        let tittelRegex = Regex(@"^[\p{L}0-9\.,-:!]{5,100}$")
        tittelRegex.IsMatch(tittel)

    module Tittel =
        let create (tittel: String) : Tittel option = 
            if isTittelValid tittel then
                Tittel tittel
                |> Some
            else
                None

        let value (Tittel tittel) = tittel

    type Kanal = private Kanal of string

    let isKanalValid (kanal: string) : bool =
        List.contains kanal ["NRK1"; "NRK2"]

    module Kanal =
        let create (kanal: string) : Kanal option =
            if isKanalValid kanal then
                Kanal kanal
                |> Some
            else
                None

        let value (Kanal kanal) = kanal
    
    type Sendetidspunkt = private {
        Starttidspunkt: DateTimeOffset
        Sluttidspunkt: DateTimeOffset
    }

    let areStartAndSluttidspunktValid (starttidspunkt: DateTimeOffset) (sluttidspunkt: DateTimeOffset) =
        starttidspunkt < sluttidspunkt

    module Sendetidspunkt =
        let create (starttidspunkt: DateTimeOffset) (sluttidspunkt: DateTimeOffset) : Sendetidspunkt option =
            if areStartAndSluttidspunktValid starttidspunkt sluttidspunkt then
                {
                    Starttidspunkt = starttidspunkt
                    Sluttidspunkt = sluttidspunkt
                }
                |> Some
            else
                None

        let starttidspunkt (sendeTidspunkt: Sendetidspunkt) = sendeTidspunkt.Starttidspunkt
        let sluttidspunkt (sendeTidspunkt: Sendetidspunkt) = sendeTidspunkt.Sluttidspunkt

    type Sending = {
        Tittel: Tittel
        Kanal: Kanal
        Sendetidspunkt: Sendetidspunkt
    }

    type Epg = Sending list

    module Sending =
        let create (tittel: string) (kanal: string) (startTidspunkt: DateTimeOffset) (sluttTidspunkt: DateTimeOffset) : Sending option =
            let tittel = Tittel.create tittel
            let kanal = Kanal.create kanal
            let sendeTidspunkt = Sendetidspunkt.create startTidspunkt sluttTidspunkt

            if tittel.IsNone || kanal.IsNone || sendeTidspunkt.IsNone then
                None
            else
                Some {
                    Tittel = tittel.Value
                    Kanal = kanal.Value
                    Sendetidspunkt = sendeTidspunkt.Value
                }
