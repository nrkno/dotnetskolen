namespace NRK.Dotnetskolen

module Dto =

    open Domain

    type SendingDto =
        { Tittel: string
          Starttidspunkt: string
          Sluttidspunkt: string }

    type EpgDto =
        { Nrk1: SendingDto list
          Nrk2: SendingDto list }

    let fromDomain (domain: Domain.Epg): EpgDto =
        let mapSendingerForKanal (kanal: string) =
            domain
            |> List.filter (fun s -> Kanal.value s.Kanal = kanal)
            |> List.map (fun s ->
                { Tittel = Tittel.value s.Tittel
                  Starttidspunkt = (Sendetidspunkt.starttidspunkt s.Sendetidspunkt).ToString("o")
                  Sluttidspunkt = (Sendetidspunkt.sluttidspunkt s.Sendetidspunkt).ToString("o") })

        { Nrk1 = mapSendingerForKanal "NRK1"
          Nrk2 = mapSendingerForKanal "NRK2" }
