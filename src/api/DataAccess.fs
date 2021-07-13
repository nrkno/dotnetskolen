namespace NRK.Dotnetskolen.Api

module DataAccess =
    open System
    open NRK.Dotnetskolen.Domain

    type SendingEntity = {
        Tittel : string
        Kanal : string
        StartTidspunkt : string
        SluttTidspunkt : string
    }

    type EpgEntity = SendingEntity list

    let database : EpgEntity =
        [
            {
                Tittel = "Testprogram"
                Kanal = "NRK1"
                StartTidspunkt = "2021-04-12T13:00:00Z"
                SluttTidspunkt = "2021-04-12T13:30:00Z"
            }
            {
                Tittel = "Testprogram"
                Kanal = "NRK2"
                StartTidspunkt = "2021-04-12T14:00:00Z"
                SluttTidspunkt = "2021-04-12T15:00:00Z"
            }
            {
                Tittel = "Testprogram"
                Kanal = "NRK3"
                StartTidspunkt = "2021-04-12T14:00:00Z"
                SluttTidspunkt = "2021-04-12T16:30:00Z"
            }
        ]

    let sendingEntityToSending (sendingEntity : SendingEntity) : Sending =
        {
            Tittel = sendingEntity.Tittel
            Kanal = sendingEntity.Kanal
            StartTidspunkt = DateTimeOffset.Parse (sendingEntity.StartTidspunkt)
            SluttTidspunkt = DateTimeOffset.Parse(sendingEntity.SluttTidspunkt)
        }

    let toDomain (epgEntity : EpgEntity) : Epg =
        epgEntity
        |> List.map sendingEntityToSending

        // Fjern alle ugyldige sendingar.
        // Ikkje gje noko feilmelding sjølv om nokon eller alle sendingar er ugyldige.
        |> List.filter isTransmissionValid

    let getAllTransmissions () : Epg =
        database
        |> toDomain
