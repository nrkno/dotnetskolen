namespace NRK.Dotnetskolen

module Dto =

  type SendingDto = {
      Tittel: string
      Starttidspunkt: string
      Sluttidspunkt: string
  }

  type EpgDto = {
    Nrk1: SendingDto list
    Nrk2: SendingDto list
  }