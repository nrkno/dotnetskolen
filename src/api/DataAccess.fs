namespace NRK.Dotnetskolen.Api

module DataAccess = 

    open System
    open NRK.Dotnetskolen.Domain

    type SendingEntity = {
        Tittel: string
        Kanal: string
        Starttidspunkt: string
        Sluttidspunkt: string
    }

    type EpgEntity = SendingEntity list

    let database = 
        [
            {
                Tittel = "Testprogram"
                Kanal = "NRK1"
                Starttidspunkt = "2021-04-12T13:00:00Z"
                Sluttidspunkt = "2021-04-12T13:30:00Z"
            }
            {
                Tittel = "Testprogram"
                Kanal = "NRK2"
                Starttidspunkt = "2021-04-12T14:00:00Z"
                Sluttidspunkt = "2021-04-12T15:00:00Z"
            }
            {
                Tittel = "Testprogram"
                Kanal = "NRK3"
                Starttidspunkt = "2021-04-12T14:00:00Z"
                Sluttidspunkt = "2021-04-12T16:30:00Z"
            }
        ]

    let sendingEntityToDomain (sendingEntity: SendingEntity) : Sending option =
        Sending.create sendingEntity.Tittel sendingEntity.Kanal (DateTimeOffset.Parse(sendingEntity.Starttidspunkt)) (DateTimeOffset.Parse(sendingEntity.Sluttidspunkt))

    let epgEntityToDomain (epgEntity: EpgEntity) : Epg =
        epgEntity
        |> List.map sendingEntityToDomain
        |> List.choose id

    let getAlleSendinger () : Epg =
        database
        |> epgEntityToDomain