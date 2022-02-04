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
let ``isChannelValid invalid channel returns false`` (channel: string) =
    let isChannelValid = isChannelValid channel

    Assert.False isChannelValid

[<Fact>]
let ``areStartAndEndTimesValid start before end returns true`` () =
    let startTime = DateTimeOffset.Now
    let endTime = startTime.AddMinutes 30.

    let areStartAndSluttTidspunktValid = areStartAndEndTimesValid startTime endTime

    Assert.True areStartAndSluttTidspunktValid

[<Fact>]
let ``areStartAndEndTimesValids start after end returns false`` () =
    let startTime = DateTimeOffset.Now
    let endTime = startTime.AddMinutes -30.

    let areStartAndSluttTidspunktValid = areStartAndEndTimesValid startTime endTime

    Assert.False areStartAndSluttTidspunktValid

[<Fact>]
let ``areStartAndEndTimesValid start equals end returns false`` () =
    let startTime = DateTimeOffset.Now
    let endTime = startTime

    let areStartAndSluttTidspunktValid = areStartAndEndTimesValid startTime endTime

    Assert.False areStartAndSluttTidspunktValid

[<Fact>]
let ``isTransmissionValid valid transmission returns true`` () =
    let now = DateTimeOffset.Now
    let transmission = {
        Sending.Tittel = "Dagsrevyen"
        Kanal = "NRK1"
        StartTidspunkt = now
        SluttTidspunkt = now.AddMinutes 30.
    }

    let isTransmissionValid = isTransmissionValid transmission

    Assert.True isTransmissionValid

[<Fact>]
let ``isTransmissionValid invalid transmission returns false`` () =
    let now = DateTimeOffset.Now
    let transmission = {
        Sending.Tittel = "@$%&/"
        Kanal = "nrk3"
        StartTidspunkt = now
        SluttTidspunkt = now.AddMinutes -30.
    }

    let isTransmissionValid = isTransmissionValid transmission

    Assert.False isTransmissionValid