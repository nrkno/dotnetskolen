namespace NRK.Dotnetskolen.IntegrationTests

module Mock =

    open System
    open NRK.Dotnetskolen.Domain

    let getAllTransmissions () : Epg =
        let now = DateTimeOffset.Now
        let past = now.AddDays(-10.)
        let future = now.AddDays(10.)
        [
            // Sendinger tilbake i tid
            (Sending.create "Testprogram" "NRK1" past (past.AddMinutes(30.))).Value
            (Sending.create "Testprogram" "NRK2" past (past.AddMinutes(30.))).Value
            // Sendinger i dag
            (Sending.create "Testprogram" "NRK1" now (now.AddMinutes(30.))).Value
            (Sending.create "Testprogram" "NRK2" now (now.AddMinutes(30.))).Value
            // Sendinger frem i tid
            (Sending.create "Testprogram" "NRK1" future (future.AddMinutes(30.))).Value
            (Sending.create "Testprogram" "NRK2" future (future.AddMinutes(30.))).Value
        ]