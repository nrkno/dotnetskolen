namespace NRK.Dotnetskolen.IntegrationTests

module Mock =

    open System
    open NRK.Dotnetskolen.Domain

    let getAlleSendinger () : Epg =
        let now = DateTimeOffset.Now
        [
            // Sendinger tilbake i tid
            {
                Tittel = "Testprogram"
                Kanal = "NRK1"
                Starttidspunkt = now.AddDays(-10.)
                Sluttidspunkt = now.AddDays(-10.).AddMinutes(30.)
            }
            {
                Tittel = "Testprogram"
                Kanal = "NRK2"
                Starttidspunkt = now.AddDays(-10.)
                Sluttidspunkt = now.AddDays(-10.).AddMinutes(30.)
            }
            // Sendinger i dag
            {
                Tittel = "Testprogram"
                Kanal = "NRK1"
                Starttidspunkt = now
                Sluttidspunkt = now.AddMinutes(30.)
            }
            {
                Tittel = "Testprogram"
                Kanal = "NRK2"
                Starttidspunkt = now
                Sluttidspunkt = now.AddMinutes(30.)
            }
            // Sendinger frem i tid
            {
                Tittel = "Testprogram"
                Kanal = "NRK1"
                Starttidspunkt = now.AddDays(10.)
                Sluttidspunkt = now.AddDays(10.).AddMinutes(30.)
            }
            {
                Tittel = "Testprogram"
                Kanal = "NRK2"
                Starttidspunkt = now.AddDays(10.)
                Sluttidspunkt = now.AddDays(10.).AddMinutes(30.)
            }
        ]