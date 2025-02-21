namespace NRK.Dotnetskolen

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
