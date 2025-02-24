namespace NRK.Dotnetskolen.Api

module DataAccess =

    open System
    open NRK.Dotnetskolen.Domain

    type TransmissionEntity = {
        Title: string
        Channel: string
        StartTime: string
        EndTime: string
    }

    type EpgEntity = TransmissionEntity list

    let database =
        [
            {
                Title = "TestProgram"
                Channel = "NRK1"
                StartTime = "2025-02-26T13:00:00Z"
                EndTime = "2025-02-26T13:30:00Z"
            }
            {
                Title = "TestProgram"
                Channel = "NRK2"
                StartTime = "2025-02-26T14:00:00Z"
                EndTime = "2025-02-26T15:00:00Z"
            }
            {
                Title = "TestProgram"
                Channel = "NRK3"
                StartTime = "2025-02-26T14:00:00Z"
                EndTime = "2025-02-26T16:30:00Z"
            }
        ]
    

    let fromTransmissionEntity (transmissionEntity: TransmissionEntity): Transmission option = 
        Transmission.create transmissionEntity.Title transmissionEntity.Channel (DateTimeOffset.Parse(transmissionEntity.StartTime)) (DateTimeOffset.Parse(transmissionEntity.EndTime))

    let fromEpgEntity (epgEntity: EpgEntity): Epg = 
        epgEntity
        |> List.choose fromTransmissionEntity
        
    let getAllTransmissions () : Epg =
        database
        |> fromEpgEntity
