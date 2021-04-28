using System;
using System.Linq;
using System.Collections.Generic;


namespace NRK.Dotnetskolen
{
    public class Sending
    {
        public string Tittel { get; set; }
        public string Kanal { get; set; }
        public DateTimeOffset StartTidspunkt { get; set; }
        public DateTimeOffset SluttTidspunkt { get; set; }
    }

    public class Epg
    {
        public List<Sending> Sendinger { get; set; }
    }
}