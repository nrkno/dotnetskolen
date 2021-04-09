module NRK.Dotnetskolen.Dto

type Sending = {
    Tittel: string
    StartTidspunkt: string
    SluttTidspunkt: string
}

type Epg = {
  Nrk1: Sending list
  Nrk2: Sending list
}

let fromDomain (domain : Domain.Epg) : Epg =
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