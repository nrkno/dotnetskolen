module Tests

open System
open Xunit
open NRK.Dotnetskolen.Domain

[<Theory>]
[<InlineData("abc12")>]
[<InlineData(".,-:!")>]
[<InlineData("ABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJ")>]
let ``isTitleValid valid title returns true`` (title: string) =
    let isTitleValid = isTitleValid title

    Assert.True isTitleValid

[<Theory>]
[<InlineData("abcd")>]
[<InlineData("@$%&/")>]
[<InlineData("abcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghija")>]
let ``isTitleValid invalid title returns false`` (title: string) =
    let isTitleValid = isTitleValid title

    Assert.False isTitleValid

[<Theory>]
[<InlineData("NRK1")>]
[<InlineData("NRK2")>]
let ``isChannelValid valid channel returns true`` (channel: string) =
    let isChannelValid = isChannelValid channel

    Assert.True isChannelValid

[<Theory>]
[<InlineData("nrk1")>]
[<InlineData("NRK3")>]
let ``isChannelvalid invalid channel returns false`` (channel: string) =
    let isChannelValid = isChannelValid channel

    Assert.False isChannelValid

[<Fact>]
let ``areStartAndEndTimesValid start before end returns true`` () =
    let startTime = DateTimeOffset.Now
    let endTime = startTime.AddMinutes 30.

    let areStartAndEndTimesValid = areStartAndEndTimesValid startTime endTime

    Assert.True areStartAndEndTimesValid

[<Fact>]
let ``areStartAndEndTimesValid start after end returns false`` () =
    let endTime = DateTimeOffset.Now
    let startTime = endTime.AddMinutes 30.

    let areStartAndEndTimesValid = areStartAndEndTimesValid startTime endTime

    Assert.False areStartAndEndTimesValid

[<Fact>]
let ``areStartAndEndTimesValid start at the same time as end returns false`` () =
    let startTime = DateTimeOffset.Now
    let endTime = startTime

    let areStartAndEndTimesValid = areStartAndEndTimesValid startTime endTime

    Assert.False areStartAndEndTimesValid

[<Fact>]
let ``isTransmissionValid valid transmission returns true`` () =
    let transmission = {
        Tittel = "Dagsrevyen"
        Kanal = "NRK1"
        StartTidspunkt = DateTimeOffset.Parse("2021-04-16T19:00:00+02:00")
        SluttTidspunkt = DateTimeOffset.Parse("2021-04-16T19:30:00+02:00")
    }

    let isTransmissionValid = isTransmissionValid transmission
    Assert.True isTransmissionValid

[<Fact>]
let ``isTransmissionValid transmission with invalid channel returns false`` () =
    let transmission = {
        Tittel = "Dagsrevyen"
        Kanal = "NRK3"
        StartTidspunkt = DateTimeOffset.Parse("2021-04-16T19:00:00+02:00")
        SluttTidspunkt = DateTimeOffset.Parse("2021-04-16T19:30:00+02:00")
    }

    let isTransmissionValid = isTransmissionValid transmission
    Assert.False isTransmissionValid
