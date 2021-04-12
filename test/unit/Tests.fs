module Tests

open System
open Xunit
open NRK.Dotnetskolen.Domain

[<Theory>]
[<InlineData("abc12")>]
[<InlineData(".,-:!")>]
[<InlineData("ABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJ")>]
let ``IsTitleValid_ValidTitle_ReturnsTrue`` (title: string) =
    // Arrange: get title from xUnit

    // Act
    let isTitleValid = IsTitleValid title

    // Assert
    Assert.True isTitleValid

[<Theory>]
[<InlineData("abcd")>]
[<InlineData("@$%&/")>]
[<InlineData("abcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghija")>]
let ``IsTitleValid_InvalidTitle_ReturnsFalse`` (title: string) =
    // Arrange: get title from xUnit

    // Act
    let isTitleValid = IsTitleValid title

    // Assert
    Assert.False isTitleValid

[<Theory>]
[<InlineData("NRK1")>]
[<InlineData("NRK2")>]
let ``IsChannelValid_ValidChannel_ReturnsTrue`` (channel: string) =
    // Arrange: get channel from xUnit

    // Act
    let isChannelValid = IsChannelValid channel

    // Assert
    Assert.True isChannelValid

[<Theory>]
[<InlineData("nrk1")>]
[<InlineData("NRK3")>]
let ``IsChannelValid_InvalidChannel_ReturnsFalse`` (channel: string) =
    // Arrange: get channel from xUnit

    // Act
    let isChannelValid = IsChannelValid channel

    // Assert
    Assert.False isChannelValid

[<Fact>]
let ``AreStartAndEndTimesValid_StartBeforeEnd_ReturnsTrue`` () =
    // Arrange
    let startTime = DateTimeOffset.Now
    let endTime = startTime.AddMinutes 30.

    // Act
    let areStartAndSluttTidspunktValid = AreStartAndEndTimesValid startTime endTime

    // Assert
    Assert.True areStartAndSluttTidspunktValid

[<Fact>]
let ``AreStartAndEndTimesValid_StartAfterEnd_ReturnsFalse`` () =
    // Arrange
    let startTime = DateTimeOffset.Now
    let endTime = startTime.AddMinutes -30.

    // Act
    let areStartAndSluttTidspunktValid = AreStartAndEndTimesValid startTime endTime

    // Assert
    Assert.False areStartAndSluttTidspunktValid

[<Fact>]
let ``AreStartAndEndTimesValid_StartEqualsEnd_ReturnsFalse`` () =
    // Arrange
    let startTime = DateTimeOffset.Now
    let endTime = startTime

    // Act
    let areStartAndSluttTidspunktValid = AreStartAndEndTimesValid startTime endTime

    // Assert
    Assert.False areStartAndSluttTidspunktValid

[<Fact>]
let ``IsTransmissionValid_ValidTransmission_ReturnsTrue`` () =
    // Arrange
    let now = DateTimeOffset.Now
    let transmission = {
        Sending.Tittel = "Dagsrevyen"
        Kanal = "NRK1"
        StartTidspunkt = now
        SluttTidspunkt = now.AddMinutes 30.
    }

    // Act
    let isTransmissionValid = IsTransmissionValid transmission

    // Assert
    Assert.True isTransmissionValid

[<Fact>]
let ``IsTransmissionValid_InValidTransmission_ReturnsFalse`` () =
    // Arrange
    let now = DateTimeOffset.Now
    let transmission = {
        Sending.Tittel = "@$%&/"
        Kanal = "nrk3"
        StartTidspunkt = now
        SluttTidspunkt = now.AddMinutes -30.
    }

    // Act
    let isTransmissionValid = IsTransmissionValid transmission

    // Assert
    Assert.False isTransmissionValid
