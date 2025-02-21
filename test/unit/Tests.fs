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
let ``isTransmissionValid valid transmission returns true`` () =
    let transmission = 
        {
            Title = "Blackshore"
            Channel = "NRK1"
            StartTime = DateTimeOffset.Now
            EndTime = DateTimeOffset.Now.AddHours 2
        }
    let isTransmissionValid = isTransmissionValid transmission
    Assert.True isTransmissionValid

[<Fact>]
let ``isTransmissionValid invalid transmission returns false`` () =
    let transmission = 
        {
            Title = "Yes & No"
            Channel = "nrk3"
            StartTime = DateTimeOffset.Now
            EndTime = DateTimeOffset.Now.AddHours -2
        }
    let isTransmissionValid = isTransmissionValid transmission
    Assert.False isTransmissionValid
