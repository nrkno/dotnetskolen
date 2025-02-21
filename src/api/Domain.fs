namespace NRK.Dotnetskolen

module Domain =

    open System

    type Transmission = {
        Title: string
        Channel: string
        StartTime: DateTimeOffset
        EndTime: DateTimeOffset
    }

    type Epg = Transmission list
