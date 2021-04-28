using System;
using System.Collections.Generic;

namespace NRK.Dotnetskolen.Api
{
    class Program
    {
        static void Main(string[] args)
        {
            Epg epg = new Epg {
                Sendinger = new List<Sending>()
                {
                    new Sending {
                        Tittel = "Dagsrevyen",
                        Kanal = "NRK1",
                        StartTidspunkt = DateTimeOffset.Parse("2021-04-16T19:00:00+02:00"),
                        SluttTidspunkt = DateTimeOffset.Parse("2021-04-16T19:30:00+02:00")
                    }
                }
            };

            foreach(var sending in epg.Sendinger)
                Console.WriteLine(sending.Tittel);
        }
    }
}