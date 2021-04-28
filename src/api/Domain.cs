using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace NRK.Dotnetskolen
{
    public class Sending
    {
        public string Tittel { get; set; }
        public string Kanal { get; set; }
        public DateTimeOffset StartTidspunkt { get; set; }
        public DateTimeOffset SluttTidspunkt { get; set; }

        public static bool IsTitleValid(string title)
        {
            Regex titleRegex = new (@"^[\p{L}0-9\.,-:!]{5,100}$");
            return titleRegex.IsMatch(title);
        }

        public static bool IsChannelValid(string channel)
        {
            Regex channelRegex = new(@"NRK1|NRK2");
            return channelRegex.IsMatch(channel);
        }

        public static bool IsStartAndEndTimeIsValid(DateTimeOffset startTime, DateTimeOffset endTime)
        {
            return endTime > startTime;
        }

        public static bool IsTransmissionValid(Sending transmission)
        {
            return IsTitleValid(transmission.Tittel) && IsChannelValid(transmission.Kanal) && IsStartAndEndTimeIsValid(transmission.StartTidspunkt, transmission.SluttTidspunkt);
        }
    }

    public class Epg
    {
        public List<Sending> Sendinger { get; set; }
    }
}