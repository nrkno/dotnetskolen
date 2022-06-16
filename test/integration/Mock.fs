namespace NRK.Dotnetskolen.IntegrationTests

module Mock =

    open System
    open NRK.Dotnetskolen.Domain

    let getAllTransmissions () : Epg =
        let now = DateTimeOffset.Now
        [
            // Sendinger tilbake i tid
            {
                Tittel = "Testprogram"
                Kanal = "NRK1"
                StartTidspunkt = now.AddDays(-10.)
                SluttTidspunkt = now.AddDays(-10.).AddMinutes(30.)
            }
            {
                Tittel = "Testprogram"
                Kanal = "NRK2"
                StartTidspunkt = now.AddDays(-10.)
                SluttTidspunkt = now.AddDays(-10.).AddMinutes(30.)
            }
            // Sendinger i dag
            {
                Tittel = "Testprogram"
                Kanal = "NRK1"
                StartTidspunkt = now
                SluttTidspunkt = now.AddMinutes(30.)
            }
            {
                Tittel = "Testprogram"
                Kanal = "NRK2"
                StartTidspunkt = now
                SluttTidspunkt = now.AddMinutes(30.)
            }
            // Sendinger frem i tid
            {
                Tittel = "Testprogram"
                Kanal = "NRK1"
                StartTidspunkt = now.AddDays(10.)
                SluttTidspunkt = now.AddDays(10.).AddMinutes(30.)
            }
            {
                Tittel = "Testprogram"
                Kanal = "NRK2"
                StartTidspunkt = now.AddDays(10.)
                SluttTidspunkt = now.AddDays(10.).AddMinutes(30.)
            }
        ]