namespace NRK.Dotnetskolen

module Dto =

    type TransmissionDto = {
        Title: string
        StartTime: string
        EndTime: string
    }

    type EpgDto = {
        Nrk1: TransmissionDto list
        Nrk2: TransmissionDto list
    }

    let fromDomain (domain: Domain.Epg) : EpgDto =
        let transmissionsForChannel channel = 
            domain
            |> List.filter(fun t -> t.Channel = channel)
            |> List.map (fun (t: Domain.Transmission) -> {
                Title = t.Title
                StartTime = t.StartTime.ToString("o")
                EndTime = t.EndTime.ToString("o")
            })
        {
        Nrk1 = transmissionsForChannel "NRK1"
        Nrk2 = transmissionsForChannel "NRK2"
        }