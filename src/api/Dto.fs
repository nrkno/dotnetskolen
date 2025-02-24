namespace NRK.Dotnetskolen
open Domain

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

    let fromDomain (domain: Domain.Epg): EpgDto =
        let mapTransmissionsForChannel (channel: string) =
            domain
            |> List.filter (fun t -> Channel.value t.Channel = channel)
            |> List.map (fun t ->
                { 
                    Title = Title.value t.Title
                    StartTime = (AirTime.startTime t.AirTime).ToString("o")
                    EndTime = (AirTime.endTime t.AirTime).ToString("o")
                })

        { 
            Nrk1 = mapTransmissionsForChannel "NRK1"
            Nrk2 = mapTransmissionsForChannel "NRK2" 
        }
