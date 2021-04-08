module NRK.Dotnetskolen.Dto

type Sending = {
    Tittel: string
    StartTidspunkt: string
    SluttTidspunkt: string
}

type Epg = {
  NRK1: Sending list
  NRK2: Sending list
}