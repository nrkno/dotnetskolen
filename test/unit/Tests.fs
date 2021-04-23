module Tests

open System
open Xunit
open NRK.Dotnetskolen.Domain

[<Theory>]
[<InlineData("abc12")>]
[<InlineData(".,-:!")>]
[<InlineData("ABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJ")>]
let ``isTitleValid_ValidTitle_ReturnsTrue`` (title: string) =
    let isTitleValid = isTitleValid title

    Assert.True isTitleValid

[<Theory>]
[<InlineData("abcd")>]
[<InlineData("@$%&/")>]
[<InlineData("abcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghija")>]
let ``isTitleValid_InvalidTitle_ReturnsFalse`` (title: string) =
    let isTitleValid = isTitleValid title

    Assert.False isTitleValid

[<Theory>]
[<InlineData("NRK1")>]
[<InlineData("NRK2")>]
let ``isChannelValid_ValidChannel_ReturnsTrue`` (channel: string) =
    let isChannelValid = isChannelValid channel

    Assert.True isChannelValid

[<Theory>]
[<InlineData("nrk1")>]
[<InlineData("NRK3")>]
let ``isChannelValid_InvalidChannel_ReturnsFalse`` (channel: string) =
    let isChannelValid = isChannelValid channel

    Assert.False isChannelValid

[<Fact>]
let ``areStartAndEndTimesValid_StartBeforeEnd_ReturnsTrue`` () =
    let startTime = DateTimeOffset.Now
    let endTime = startTime.AddMinutes 30.

    let areStartAndSluttTidspunktValid = areStartAndEndTimesValid startTime endTime

    Assert.True areStartAndSluttTidspunktValid

[<Fact>]
let ``areStartAndEndTimesValid_StartAfterEnd_ReturnsFalse`` () =
    let startTime = DateTimeOffset.Now
    let endTime = startTime.AddMinutes -30.

    let areStartAndSluttTidspunktValid = areStartAndEndTimesValid startTime endTime

    Assert.False areStartAndSluttTidspunktValid

[<Fact>]
let ``areStartAndEndTimesValid_StartEqualsEnd_ReturnsFalse`` () =
    let startTime = DateTimeOffset.Now
    let endTime = startTime

    let areStartAndSluttTidspunktValid = areStartAndEndTimesValid startTime endTime

    Assert.False areStartAndSluttTidspunktValid

[<Fact>]
let ``Sending.create valid transmission returns Some`` () =
    let now = DateTimeOffset.Now
    let transmission = Sending.create "Dagsrevyen" "NRK1" now (now.AddMinutes 30.)

    match transmission with
    | Some t ->
        Assert.True true
        Assert.Equal("Dagsrevyen", Tittel.value t.Tittel)
        Assert.Equal("NRK1", Kanal.value t.Kanal)
        Assert.Equal(now, Sendetidspunkt.startTidspunkt t.Sendetidspunkt)
        Assert.Equal(now.AddMinutes 30., Sendetidspunkt.sluttTidspunkt t.Sendetidspunkt)
    | None -> Assert.True false

[<Fact>]
let ``Sending.create invalid transmission returns None`` () =
    let now = DateTimeOffset.Now
    let transmission = Sending.create "@$%&/" "nrk3" now (now.AddMinutes 30.)

    Assert.True transmission.IsNone
