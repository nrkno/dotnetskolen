namespace NRK.Dotnetskolen

module Dto =

    open Domain

    type SendingDto =
        { Tittel: string
          StartTidspunkt: string
          SluttTidspunkt: string }

    type EpgDto =
        { Nrk1: SendingDto list
          Nrk2: SendingDto list }

    let fromDomain (domain: Domain.Epg): EpgDto =
        let mapSendingerForKanal (kanal: string) =
            domain
            |> List.filter (fun s -> Kanal.value s.Kanal = kanal)
            |> List.map (fun s ->
                { Tittel = Tittel.value s.Tittel
                  StartTidspunkt = (Sendetidspunkt.startTidspunkt s.Sendetidspunkt).ToString("o")
                  SluttTidspunkt = (Sendetidspunkt.sluttTidspunkt s.Sendetidspunkt).ToString("o") })

        { Nrk1 = mapSendingerForKanal "NRK1"
          Nrk2 = mapSendingerForKanal "NRK2" }
