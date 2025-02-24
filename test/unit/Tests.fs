module Tests

open Xunit
open NRK.Dotnetskolen.Domain
open System

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
let ``areStartTimeAndEndTimeValid start before end returns true`` () =
    let startTime = DateTimeOffset.Now
    let endTime = startTime.AddMinutes 30.

    let areStartTimeAndEndTimeValid = areStartTimeAndEndTimeValid startTime endTime

    Assert.True areStartTimeAndEndTimeValid

[<Fact>]
let ``areStartTimeAndEndTimeValid start after end returns false`` () =
    let endTime = DateTimeOffset.Now
    let startTime = endTime.AddMinutes 30.

    let areStartTimeAndEndTimeValid = areStartTimeAndEndTimeValid startTime endTime

    Assert.False areStartTimeAndEndTimeValid

[<Fact>]
let ``areStartTimeAndEndTimeValid start equal end returns false`` () =
    let startTime = DateTimeOffset.Now
    let endTime = startTime

    let areStartTimeAndEndTimeValid = areStartTimeAndEndTimeValid startTime endTime

    Assert.False areStartTimeAndEndTimeValid

[<Fact>]
let ``Transmission.create valid transmission returns Some`` () =
    let now = DateTimeOffset.Now
    let transmission = Transmission.create "Blackshore" "NRK1" now (now.AddMinutes 30.)

    match transmission with
    | Some t ->
        Assert.Equal("Blackshore", Title.value t.Title)
        Assert.Equal("NRK1", Channel.value t.Channel)
        Assert.Equal(now, AirTime.startTime t.AirTime)
        Assert.Equal(now.AddMinutes 30., AirTime.endTime t.AirTime)
    | None -> Assert.True false

[<Fact>]
let ``Transmission.create invalid transmission returns None`` () =
    let now = DateTimeOffset.Now
    let transmission = Transmission.create "@$%&/" "nrk3" now (now.AddMinutes 30.)

    Assert.True transmission.IsNone
