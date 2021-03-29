module Tests

open Xunit
open NRK.Dotnetskolen.Domain

[<Fact>]
let ``IsProgramIdValid_ValidProgramId_ReturnsTrue`` () =
    // Arrange
    let validProgramId = "abcd12345678"

    // Act
    let isProgramIdValid = IsProgramIdValid(validProgramId)

    // Assert
    Assert.True(isProgramIdValid)

[<Fact>]
let ``IsProgramIdValid_LettersAndDigitsSwapped_ReturnsFalse`` () =
    // Arrange
    let validProgramId = "12345678abcd"

    // Act
    let isProgramIdValid = IsProgramIdValid(validProgramId)

    // Assert
    Assert.False(isProgramIdValid)

[<Fact>]
let ``IsProgramIdValid_InvalidProgramId_ReturnsFalse`` () =
    // Arrange
    let invalidProgramId = "-_.,;:"

    // Act
    let isProgramIdValid = IsProgramIdValid(invalidProgramId)

    // Assert
    Assert.False(isProgramIdValid)

[<Fact>]
let ``IsTitleValid_ValidTitle_ReturnsTrue`` () =
    // Arrange
    let validProgramId = "Eksempelprogram"

    // Act
    let isProgramIdValid = IsTitleValid(validProgramId)

    // Assert
    Assert.True(isProgramIdValid)

[<Fact>]
let ``IsTitleValid_TitleWithTwoCharacters_ReturnsFalse`` () =
    // Arrange
    let validProgramId = "ab"

    // Act
    let isProgramIdValid = IsTitleValid(validProgramId)

    // Assert
    Assert.False(isProgramIdValid)

[<Fact>]
let ``IsTitleValid_TitleWithOneHundredAndTwoCharacters_ReturnsFalse`` () =
    // Arrange
    let validProgramId = "012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901"

    // Act
    let isProgramIdValid = IsTitleValid(validProgramId)

    // Assert
    Assert.False(isProgramIdValid)
