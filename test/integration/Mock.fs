namespace NRK.Dotnetskolen.IntegrationTests

module Mock =

    open System
    open NRK.Dotnetskolen.Domain

    let getAllTransmissions () : Epg =
        let now = DateTimeOffset.Now
        [
            // Transmissions back in time
            {
                Title = "TestProgram"
                Channel = "NRK1"
                StartTime = now.AddDays(-10.)
                EndTime = now.AddDays(-10.).AddMinutes(30.)
            }
            {
                Title = "TestProgram"
                Channel = "NRK2"
                StartTime = now.AddDays(-10.)
                EndTime = now.AddDays(-10.).AddMinutes(30.)
            }
            // Today's transmissions
            {
                Title = "TestProgram"
                Channel = "NRK1"
                StartTime = now
                EndTime = now.AddMinutes(30.)
            }
            {
                Title = "TestProgram"
                Channel = "NRK2"
                StartTime = now
                EndTime = now.AddMinutes(30.)
            }
            // Future transmissions
            {
                Title = "TestProgram"
                Channel = "NRK1"
                StartTime = now.AddDays(10.)
                EndTime = now.AddDays(10.).AddMinutes(30.)
            }
            {
                Title = "TestProgram"
                Channel = "NRK2"
                StartTime = now.AddDays(10.)
                EndTime = now.AddDays(10.).AddMinutes(30.)
            }
        ]