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
        let sendingToSendingDto (sending : Domain.Sending) : SendingDto =
            {
                Tittel = sending.Tittel
                StartTidspunkt = sending.StartTidspunkt.ToString("o")
                SluttTidspunkt = sending.SluttTidspunkt.ToString("o")
            }

        let epgToEpgDtoForKanal kanal =
            domain
            |> List.filter (fun sending -> sending.Kanal = kanal)
            |> List.map sendingToSendingDto

        {
            Nrk1 = epgToEpgDtoForKanal "NRK1"
            Nrk2 = epgToEpgDtoForKanal "NRK2"
        }
