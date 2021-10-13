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

[<Theory>]
[<InlineData("Supernytt","NRK2")>]
[<InlineData("Mittprogram","NRK1")>]
let ``isTransValid valid returns true`` (title: string)(channel: string) =
    let transmission : Sending = Sending(Tittel = title, Kanal = channel, StartTidspunkt = DateTimeOffset.Parse("2021-04-16T19:00:00+02:00"), SluttTidspunkt = DateTimeOffset.Parse("2021-04-16T19:30:00+02:00"))
    let areStartAndSluttTidspunktValid = isTransmissionValid transmission
    // let startTid = DateTimeOffset.Now
    // let sluttTid = startTime.AddMinutes 30.
    // let areStartAndSluttTidspunktValid = isTransmissionValid title channel startTid sluttTid
    Assert.True isTransmissionValid


[<Theory>]
[<InlineData("+++","Nrk2")>]
[<InlineData("Mittprogram","NRK1")>]
let ``isTransValid invalid returns false`` (title: string)(channel: string) =

    let areStartAndSluttTidspunktValid = isTransmissionValid transmission
    Assert.False isTransmissionValid
