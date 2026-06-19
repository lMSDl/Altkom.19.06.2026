using Hangman.ConsoleApp;
using Hangman.ConsoleApp.Models;
using Xunit;

namespace Hangman.UnitTests;

public class InputValidatorTests
{
    [Fact]
    public void Constructor_PolishLanguage_InitializesPolishLetters()
    {
        // Arrange
        var language = Language.Polish;

        // Act
        var validator = new InputValidator(language);

        // Assert
        Assert.NotNull(validator);
    }

    [Fact]
    public void Constructor_EnglishLanguage_InitializesInstance()
    {
        // Arrange
        var language = Language.English;

        // Act
        var validator = new InputValidator(language);

        // Assert
        Assert.NotNull(validator);
    }

    [Fact]
    public void IsValidLetter_NullInput_ReturnsFalse()
    {
        // Arrange
        var validator = new InputValidator(Language.English);
        string? input = null;

        // Act
        var result = validator.IsValidLetter(input!, out var letter);

        // Assert
        Assert.False(result);
        Assert.Equal('\0', letter);
    }

    [Fact]
    public void IsValidLetter_EmptyInput_ReturnsFalse()
    {
        // Arrange
        var validator = new InputValidator(Language.English);
        var input = "";

        // Act
        var result = validator.IsValidLetter(input, out var letter);

        // Assert
        Assert.False(result);
        Assert.Equal('\0', letter);
    }

    [Fact]
    public void IsValidLetter_WhitespaceInput_ReturnsFalse()
    {
        // Arrange
        var validator = new InputValidator(Language.English);
        var input = " ";

        // Act
        var result = validator.IsValidLetter(input, out var letter);

        // Assert
        Assert.False(result);
        Assert.Equal('\0', letter);
    }

    [Fact]
    public void IsValidLetter_MultipleCharacters_ReturnsFalse()
    {
        // Arrange
        var validator = new InputValidator(Language.English);
        var input = "AB";

        // Act
        var result = validator.IsValidLetter(input, out var letter);

        // Assert
        Assert.False(result);
        Assert.Equal('\0', letter);
    }

    [Fact]
    public void IsValidLetter_ValidEnglishLowercase_ReturnsTrue()
    {
        // Arrange
        var validator = new InputValidator(Language.English);
        var input = "a";

        // Act
        var result = validator.IsValidLetter(input, out var letter);

        // Assert
        Assert.True(result);
        Assert.Equal('A', letter);
    }

    [Fact]
    public void IsValidLetter_ValidEnglishUppercase_ReturnsTrue()
    {
        // Arrange
        var validator = new InputValidator(Language.English);
        var input = "Z";

        // Act
        var result = validator.IsValidLetter(input, out var letter);

        // Assert
        Assert.True(result);
        Assert.Equal('Z', letter);
    }

    [Fact]
    public void IsValidLetter_EnglishDigit_ReturnsFalse()
    {
        // Arrange
        var validator = new InputValidator(Language.English);
        var input = "5";

        // Act
        var result = validator.IsValidLetter(input, out var letter);

        // Assert
        Assert.False(result);
        Assert.Equal('5', letter);
    }

    [Fact]
    public void IsValidLetter_EnglishSpecialCharacter_ReturnsFalse()
    {
        // Arrange
        var validator = new InputValidator(Language.English);
        var input = "!";

        // Act
        var result = validator.IsValidLetter(input, out var letter);

        // Assert
        Assert.False(result);
        Assert.Equal('!', letter);
    }

    [Fact]
    public void IsValidLetter_PolishValidLetter_ReturnsTrue()
    {
        // Arrange
        var validator = new InputValidator(Language.Polish);
        var input = "ą";

        // Act
        var result = validator.IsValidLetter(input, out var letter);

        // Assert
        Assert.True(result);
        Assert.Equal('Ą', letter);
    }

    [Fact]
    public void IsValidLetter_PolishValidLetterUppercase_ReturnsTrue()
    {
        // Arrange
        var validator = new InputValidator(Language.Polish);
        var input = "Ł";

        // Act
        var result = validator.IsValidLetter(input, out var letter);

        // Assert
        Assert.True(result);
        Assert.Equal('Ł', letter);
    }

    [Fact]
    public void IsValidLetter_PolishInvalidCharacter_ReturnsFalse()
    {
        // Arrange
        var validator = new InputValidator(Language.Polish);
        var input = "1";

        // Act
        var result = validator.IsValidLetter(input, out var letter);

        // Assert
        Assert.False(result);
        Assert.Equal('1', letter);
    }

    [Fact]
    public void IsValidLetter_PolishAllValidLetters_ReturnsTrue()
    {
        // Arrange
        var validator = new InputValidator(Language.Polish);
        var validLetters = new[] { 'A', 'Ą', 'B', 'C', 'Ć', 'D', 'E', 'Ę', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'Ł', 
                                    'M', 'N', 'Ń', 'O', 'Ó', 'P', 'Q', 'R', 'S', 'Ś', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'Ź', 'Ż' };

        foreach (var validLetter in validLetters)
        {
            // Act
            var result = validator.IsValidLetter(validLetter.ToString(), out var letter);

            // Assert
            Assert.True(result, $"Letter {validLetter} should be valid");
            Assert.Equal(validLetter, letter);
        }
    }

    [Fact]
    public void IsValidLetter_PolishBasicEnglishLetter_ReturnsTrue()
    {
        // Arrange
        var validator = new InputValidator(Language.Polish);
        var input = "a";

        // Act
        var result = validator.IsValidLetter(input, out var letter);

        // Assert
        Assert.True(result);
        Assert.Equal('A', letter);
    }

    [Fact]
    public void IsAlreadyGuessed_LetterExists_ReturnsTrue()
    {
        // Arrange
        var validator = new InputValidator(Language.English);
        var guessedLetters = new HashSet<char> { 'A', 'B', 'C' };
        var letter = 'A';

        // Act
        var result = validator.IsAlreadyGuessed(letter, guessedLetters);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsAlreadyGuessed_LetterNotExists_ReturnsFalse()
    {
        // Arrange
        var validator = new InputValidator(Language.English);
        var guessedLetters = new HashSet<char> { 'A', 'B', 'C' };
        var letter = 'D';

        // Act
        var result = validator.IsAlreadyGuessed(letter, guessedLetters);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsAlreadyGuessed_EmptySet_ReturnsFalse()
    {
        // Arrange
        var validator = new InputValidator(Language.English);
        var guessedLetters = new HashSet<char>();
        var letter = 'A';

        // Act
        var result = validator.IsAlreadyGuessed(letter, guessedLetters);

        // Assert
        Assert.False(result);
    }
}
