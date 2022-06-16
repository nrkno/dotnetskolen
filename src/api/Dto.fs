namespace NRK.Dotnetskolen

module Dto =

  type SendingDto = {
      Tittel: string
      StartTidspunkt: string
      SluttTidspunkt: string
  }

  type EpgDto = {
    Nrk1: SendingDto list
    Nrk2: SendingDto list
  }

  let fromDomain (domain : Domain.Epg) : EpgDto =
      let mapSendingerForKanal (kanal : string) =
          domain 
              |> List.filter (fun s -> s.Kanal = kanal) 
              |> List.map (fun s -> { 
                  Tittel = s.Tittel
                  StartTidspunkt = s.StartTidspunkt.ToString("o")
                  SluttTidspunkt = s.SluttTidspunkt.ToString("o")
              })
      {
          Nrk1 = mapSendingerForKanal "NRK1"
          Nrk2 = mapSendingerForKanal "NRK2"
      }