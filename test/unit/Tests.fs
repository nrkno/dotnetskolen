module Tests

open Xunit
open NRK.Dotnetskolen.Domain

[<Fact>]
let ``IsTitleValid_TitleWithFiveCharacters_ReturnsTrue`` () =
    // Arrange
    let validProgramId = "abcde"

    // Act
    let isProgramIdValid = IsTitleValid(validProgramId)

    // Assert
    Assert.True(isProgramIdValid)

[<Fact>]
let ``IsTitleValid_TitleWithOneHundredCharacters_ReturnsTrue`` () =
    // Arrange
    let validProgramId = "abcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghij"

    // Act
    let isProgramIdValid = IsTitleValid(validProgramId)

    // Assert
    Assert.True(isProgramIdValid)

[<Fact>]
let ``IsTitleValid_TitleWithFourCharacters_ReturnsFalse`` () =
    // Arrange
    let validProgramId = "abcd"

    // Act
    let isProgramIdValid = IsTitleValid(validProgramId)

    // Assert
    Assert.False(isProgramIdValid)

[<Fact>]
let ``IsTitleValid_TitleWithOneHundredAndOneCharacters_ReturnsFalse`` () =
    // Arrange
    let validProgramId = "abcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghija"

    // Act
    let isProgramIdValid = IsTitleValid(validProgramId)

    // Assert
    Assert.False(isProgramIdValid)
