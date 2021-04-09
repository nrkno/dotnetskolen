module Tests

open System
open Xunit
open NRK.Dotnetskolen.Domain

[<Fact>]
let ``IsTitleValid_TitleWithFiveLettersAndNumbers_ReturnsTrue`` () =
    // Arrange
    let title = "abc12"

    // Act
    let isTitleValid = IsTitleValid title

    // Assert
    Assert.True isTitleValid

[<Fact>]
let ``IsTitleValid_TitleWithOneHundredUpperCaseLetters_ReturnsTrue`` () =
    // Arrange
    let title = "ABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJ"

    // Act
    let isTitleValid = IsTitleValid title

    // Assert
    Assert.True isTitleValid

[<Fact>]
let ``IsTitleValid_TitleWithFourLetters_ReturnsFalse`` () =
    // Arrange
    let title = "abcd"

    // Act
    let isTitleValid = IsTitleValid title

    // Assert
    Assert.False isTitleValid

[<Fact>]
let ``IsTitleValid_TitleWithOneHundredAndOneLetters_ReturnsFalse`` () =
    // Arrange
    let title = "abcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghija"

    // Act
    let isTitleValid = IsTitleValid title

    // Assert
    Assert.False isTitleValid

[<Fact>]
let ``IsTitleValid_TitleWithFiveSpecialCharacters_ReturnsTrue`` () =
    // Arrange
    let title = ".,-:!"

    // Act
    let isTitleValid = IsTitleValid title

    // Assert
    Assert.True isTitleValid

[<Fact>]
let ``IsTitleValid_TitleWithFiveIllegalCharacters_ReturnsFalse`` () =
    // Arrange
    let title = "@$%&/"

    // Act
    let isTitleValid = IsTitleValid title

    // Assert
    Assert.False isTitleValid

[<Fact>]
let ``IsChannelValid_NRK1UpperCase_ReturnsTrue`` () =
    // Arrange
    let channel = "NRK1"

    // Act
    let isChannelValid = IsChannelValid channel

    // Assert
    Assert.True isChannelValid

[<Fact>]
let ``IsChannelValid_NRK2UpperCase_ReturnsTrue`` () =
    // Arrange
    let channel = "NRK2"

    // Act
    let isChannelValid = IsChannelValid channel

    // Assert
    Assert.True isChannelValid

[<Fact>]
let ``IsChannelValid_NRK1LowerCase_ReturnsFalse`` () =
    // Arrange
    let channel = "nrk1"

    // Act
    let isChannelValid = IsChannelValid channel

    // Assert
    Assert.False isChannelValid

[<Fact>]
let ``IsChannelValid_NRK3UpperCase_ReturnsFalse`` () =
    // Arrange
    let channel = "NRK3"

    // Act
    let isChannelValid = IsChannelValid channel

    // Assert
    Assert.False isChannelValid

[<Fact>]
let ``AreStartAndEndTimesValid_StartBeforeEnd_ReturnsTrue`` () =
    // Arrange
    let startTime = DateTime.Now
    let endTime = startTime.AddMinutes 30.

    // Act
    let areStartAndSluttTidspunktValid = AreStartAndEndTimesValid startTime endTime

    // Assert
    Assert.True areStartAndSluttTidspunktValid

[<Fact>]
let ``AreStartAndEndTimesValid_StartAfterEnd_ReturnsFalse`` () =
    // Arrange
    let startTime = DateTime.Now
    let endTime = startTime.AddMinutes -30.

    // Act
    let areStartAndSluttTidspunktValid = AreStartAndEndTimesValid startTime endTime

    // Assert
    Assert.False areStartAndSluttTidspunktValid

[<Fact>]
let ``AreStartAndEndTimesValid_StartEqualsEnd_ReturnsFalse`` () =
    // Arrange
    let startTime = DateTime.Now
    let endTime = startTime

    // Act
    let areStartAndSluttTidspunktValid = AreStartAndEndTimesValid startTime endTime

    // Assert
    Assert.False areStartAndSluttTidspunktValid

[<Fact>]
let ``IsTransmissionValid_ValidTransmission_ReturnsTrue`` () =
    // Arrange
    let now = DateTime.Now
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
    let now = DateTime.Now
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
