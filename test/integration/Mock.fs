namespace NRK.Dotnetskolen.IntegrationTests

module Mock =

    open System
    open NRK.Dotnetskolen.Domain

    let getAllTransmissions () : Epg =
        let now = DateTimeOffset.Now
        let past = now.AddDays(-10.)
        let future = now.AddDays(10.)
        [
            // Transmissions back in time
            (Transmission.create "TestProgram" "NRK1" past (past.AddMinutes(30.))).Value
            (Transmission.create "TestProgram" "NRK2" past (past.AddMinutes(30.))).Value
            // Today's transmissions
            (Transmission.create "TestProgram" "NRK1" now (now.AddMinutes(30.))).Value
            (Transmission.create "TestProgram" "NRK2" now (now.AddMinutes(30.))).Value
            // Forward transmissions
            (Transmission.create "TestProgram" "NRK1" future (future.AddMinutes(30.))).Value
            (Transmission.create "TestProgram" "NRK2" future (future.AddMinutes(30.))).Value
        ]
