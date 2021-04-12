module Tests

open System
open Xunit
open NRK.Dotnetskolen.Domain

[<Theory>]
[<InlineData("abc12")>]
[<InlineData(".,-:!")>]
[<InlineData("ABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJ")>]
let ``IsTitleValid_ValidTitle_ReturnsTrue`` (title: string) =
    let isTitleValid = IsTitleValid title

    Assert.True isTitleValid

[<Theory>]
[<InlineData("abcd")>]
[<InlineData("@$%&/")>]
[<InlineData("abcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghija")>]
let ``IsTitleValid_InvalidTitle_ReturnsFalse`` (title: string) =
    let isTitleValid = IsTitleValid title

    Assert.False isTitleValid

[<Theory>]
[<InlineData("NRK1")>]
[<InlineData("NRK2")>]
let ``IsChannelValid_ValidChannel_ReturnsTrue`` (channel: string) =
    let isChannelValid = IsChannelValid channel

    Assert.True isChannelValid

[<Theory>]
[<InlineData("nrk1")>]
[<InlineData("NRK3")>]
let ``IsChannelValid_InvalidChannel_ReturnsFalse`` (channel: string) =
    let isChannelValid = IsChannelValid channel

    Assert.False isChannelValid

[<Fact>]
let ``AreStartAndEndTimesValid_StartBeforeEnd_ReturnsTrue`` () =
    let startTime = DateTimeOffset.Now
    let endTime = startTime.AddMinutes 30.

    let areStartAndSluttTidspunktValid = AreStartAndEndTimesValid startTime endTime

    Assert.True areStartAndSluttTidspunktValid

[<Fact>]
let ``AreStartAndEndTimesValid_StartAfterEnd_ReturnsFalse`` () =
    let startTime = DateTimeOffset.Now
    let endTime = startTime.AddMinutes -30.

    let areStartAndSluttTidspunktValid = AreStartAndEndTimesValid startTime endTime

    Assert.False areStartAndSluttTidspunktValid

[<Fact>]
let ``AreStartAndEndTimesValid_StartEqualsEnd_ReturnsFalse`` () =
    let startTime = DateTimeOffset.Now
    let endTime = startTime

    let areStartAndSluttTidspunktValid = AreStartAndEndTimesValid startTime endTime

    Assert.False areStartAndSluttTidspunktValid

[<Fact>]
let ``IsTransmissionValid_ValidTransmission_ReturnsTrue`` () =
    let now = DateTimeOffset.Now
    let transmission = {
        Sending.Tittel = "Dagsrevyen"
        Kanal = "NRK1"
        StartTidspunkt = now
        SluttTidspunkt = now.AddMinutes 30.
    }

    let isTransmissionValid = IsTransmissionValid transmission

    Assert.True isTransmissionValid

[<Fact>]
let ``IsTransmissionValid_InValidTransmission_ReturnsFalse`` () =
    let now = DateTimeOffset.Now
    let transmission = {
        Sending.Tittel = "@$%&/"
        Kanal = "nrk3"
        StartTidspunkt = now
        SluttTidspunkt = now.AddMinutes -30.
    }

    let isTransmissionValid = IsTransmissionValid transmission

    Assert.False isTransmissionValid
