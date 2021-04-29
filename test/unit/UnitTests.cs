using System;
using NRK.Dotnetskolen.Api.Domain;
using Xunit;

namespace NRK.Dotnetskolen.UnitTests
{
    public class UnitTests
    {
        [Theory]
        [InlineData("abc12")]
        [InlineData(".,-:!")]
        [InlineData("ABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJ")]
        public void IsTitleValid_ValidTitle_ReturnsTrue(string tittel)
        {
            Assert.True(Sending.IsTitleValid(tittel));
        }

        [Theory]
        [InlineData("abcd")]
        [InlineData("@$%&/")]
        [InlineData("abcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghija")]
        public void IsTitleValid_InvalidTitle_ReturnsFalse(string title)
        {
            Assert.False(Sending.IsTitleValid(title));
        }

        [Theory]
        [InlineData("NRK1")]
        [InlineData("NRK2")]
        public void IsChannelValid_ValidChannel_ReturnsTrue(string channel)
        {
            Assert.True(Sending.IsChannelValid(channel));
        }

        [Theory]
        [InlineData("nrk1")]
        [InlineData("NRK3")]
        public void IsChannelValid_InvalidChannel_ReturnsFalse(string channel)
        {
            Assert.False(Sending.IsChannelValid(channel));
        }

        [Fact]
        public void AreStartAndEndTimesValid_StartBeforeEnd_ReturnsTrue()
        {
            DateTimeOffset startTime = DateTimeOffset.Now;

            Assert.True(Sending.IsStartAndEndTimeIsValid(startTime, startTime.AddMinutes(30)));
        }

        [Theory]
        [InlineData("Urix", "NRK1", "2021-04-29T22:00:00+02", "2021-04-29T22:45:00+02", false)]
        [InlineData("Kveldsnytt", "NRK1", "2021-04-29T22:00:00+02", "2021-04-29T22:45:00+02", true)]
        public void IsTransmissionValid_Sending_VaryingOutput(string title, string channel, string start, string end, bool valid)
        {
            Assert.Equal(valid, Sending.IsTransmissionValid(new Sending { Tittel = title, Kanal = channel, StartTidspunkt = DateTimeOffset.Parse(start), SluttTidspunkt = DateTimeOffset.Parse(end) }));
        }
    }
}