using AutoFixture;
using Hangman.ConsoleApp.Localization;
using Hangman.ConsoleApp.Models;
using Xunit;

namespace Hangman.UnitTests;


public class LocalizationManagerTests
{
    private readonly Fixture _fixture = new();

    [Fact]
    public void Constructor_WithPolishLanguage_CreatesInstance()
    {
        // Arrange
        var language = Language.Polish;

        // Act
        var manager = new LocalizationManager(language);

        // Assert
        Assert.NotNull(manager);
    }

    [Fact]
    public void Constructor_WithEnglishLanguage_CreatesInstance()
    {
        // Arrange
        var language = Language.English;

        // Act
        var manager = new LocalizationManager(language);

        // Assert
        Assert.NotNull(manager);
    }

    [Fact]
    public void SelectLanguage_WithPolishLanguage_ReturnsPolishString()
    {
        // Arrange
        var language = Language.Polish;
        var manager = new LocalizationManager(language);

        // Act
        var result = manager.SelectLanguage;

        // Assert
        Assert.Equal("Wybierz j\u0119zyk / Select language:", result);
    }

    [Fact]
    public void SelectLanguage_WithEnglishLanguage_ReturnsEnglishString()
    {
        // Arrange
        var language = Language.English;
        var manager = new LocalizationManager(language);

        // Act
        var result = manager.SelectLanguage;

        // Assert
        Assert.Equal("Wybierz j\u0119zyk / Select language:", result);
    }

    [Fact]
    public void LanguagePolish_WithPolishLanguage_ReturnsPolishString()
    {
        // Arrange
        var language = Language.Polish;
        var manager = new LocalizationManager(language);

        // Act
        var result = manager.LanguagePolish;

        // Assert
        Assert.Equal("1. Polski", result);
    }

    [Fact]
    public void LanguagePolish_WithEnglishLanguage_ReturnsEnglishString()
    {
        // Arrange
        var language = Language.English;
        var manager = new LocalizationManager(language);

        // Act
        var result = manager.LanguagePolish;

        // Assert
        Assert.Equal("1. Polski", result);
    }

    [Fact]
    public void LanguageEnglish_WithPolishLanguage_ReturnsPolishString()
    {
        // Arrange
        var language = Language.Polish;
        var manager = new LocalizationManager(language);

        // Act
        var result = manager.LanguageEnglish;

        // Assert
        Assert.Equal("2. English", result);
    }

    [Fact]
    public void LanguageEnglish_WithEnglishLanguage_ReturnsEnglishString()
    {
        // Arrange
        var language = Language.English;
        var manager = new LocalizationManager(language);

        // Act
        var result = manager.LanguageEnglish;

        // Assert
        Assert.Equal("2. English", result);
    }

    [Fact]
    public void Welcome_WithPolishLanguage_ReturnsPolishString()
    {
        // Arrange
        var language = Language.Polish;
        var manager = new LocalizationManager(language);

        // Act
        var result = manager.Welcome;

        // Assert
        Assert.Equal("Witaj w grze Wisielec!", result);
    }

    [Fact]
    public void Welcome_WithEnglishLanguage_ReturnsEnglishString()
    {
        // Arrange
        var language = Language.English;
        var manager = new LocalizationManager(language);

        // Act
        var result = manager.Welcome;

        // Assert
        Assert.Equal("Welcome to Hangman!", result);
    }

    [Fact]
    public void SelectDifficulty_WithPolishLanguage_ReturnsPolishString()
    {
        // Arrange
        var language = Language.Polish;
        var manager = new LocalizationManager(language);

        // Act
        var result = manager.SelectDifficulty;

        // Assert
        Assert.Equal("Wybierz poziom trudnoœci:", result);
    }

    [Fact]
    public void SelectDifficulty_WithEnglishLanguage_ReturnsEnglishString()
    {
        // Arrange
        var language = Language.English;
        var manager = new LocalizationManager(language);

        // Act
        var result = manager.SelectDifficulty;

        // Assert
        Assert.Equal("Select difficulty level:", result);
    }

    [Fact]
    public void DifficultyEasy_WithPolishLanguage_ReturnsPolishString()
    {
        // Arrange
        var language = Language.Polish;
        var manager = new LocalizationManager(language);

        // Act
        var result = manager.DifficultyEasy;

        // Assert
        Assert.Equal("1. £atwy (3-5 liter)", result);
    }

    [Fact]
    public void DifficultyEasy_WithEnglishLanguage_ReturnsEnglishString()
    {
        // Arrange
        var language = Language.English;
        var manager = new LocalizationManager(language);

        // Act
        var result = manager.DifficultyEasy;

        // Assert
        Assert.Equal("1. Easy (3-5 letters)", result);
    }

    [Fact]
    public void DifficultyMedium_WithPolishLanguage_ReturnsPolishString()
    {
        // Arrange
        var language = Language.Polish;
        var manager = new LocalizationManager(language);

        // Act
        var result = manager.DifficultyMedium;

        // Assert
        Assert.Equal("2. Œredni (6-8 liter)", result);
    }

    [Fact]
    public void DifficultyMedium_WithEnglishLanguage_ReturnsEnglishString()
    {
        // Arrange
        var language = Language.English;
        var manager = new LocalizationManager(language);

        // Act
        var result = manager.DifficultyMedium;

        // Assert
        Assert.Equal("2. Medium (6-8 letters)", result);
    }

    [Fact]
    public void DifficultyHard_WithPolishLanguage_ReturnsPolishString()
    {
        // Arrange
        var language = Language.Polish;
        var manager = new LocalizationManager(language);

        // Act
        var result = manager.DifficultyHard;

        // Assert
        Assert.Equal("3. Trudny (9+ liter)", result);
    }

    [Fact]
    public void DifficultyHard_WithEnglishLanguage_ReturnsEnglishString()
    {
        // Arrange
        var language = Language.English;
        var manager = new LocalizationManager(language);

        // Act
        var result = manager.DifficultyHard;

        // Assert
        Assert.Equal("3. Hard (9+ letters)", result);
    }

    [Fact]
    public void Exit_WithPolishLanguage_ReturnsPolishString()
    {
        // Arrange
        var language = Language.Polish;
        var manager = new LocalizationManager(language);

        // Act
        var result = manager.Exit;

        // Assert
        Assert.Equal("4. Wyjœcie", result);
    }

    [Fact]
    public void Exit_WithEnglishLanguage_ReturnsEnglishString()
    {
        // Arrange
        var language = Language.English;
        var manager = new LocalizationManager(language);

        // Act
        var result = manager.Exit;

        // Assert
        Assert.Equal("4. Exit", result);
    }

    [Fact]
    public void EnterLetter_WithPolishLanguage_ReturnsPolishString()
    {
        // Arrange
        var language = Language.Polish;
        var manager = new LocalizationManager(language);

        // Act
        var result = manager.EnterLetter;

        // Assert
        Assert.Equal("Podaj literê: ", result);
    }

    [Fact]
    public void EnterLetter_WithEnglishLanguage_ReturnsEnglishString()
    {
        // Arrange
        var language = Language.English;
        var manager = new LocalizationManager(language);

        // Act
        var result = manager.EnterLetter;

        // Assert
        Assert.Equal("Enter a letter: ", result);
    }

    [Fact]
    public void InvalidInput_WithPolishLanguage_ReturnsPolishString()
    {
        // Arrange
        var language = Language.Polish;
        var manager = new LocalizationManager(language);

        // Act
        var result = manager.InvalidInput;

        // Assert
        Assert.Equal("Nieprawid³owe dane! Podaj pojedyncz¹ literê.", result);
    }

    [Fact]
    public void InvalidInput_WithEnglishLanguage_ReturnsEnglishString()
    {
        // Arrange
        var language = Language.English;
        var manager = new LocalizationManager(language);

        // Act
        var result = manager.InvalidInput;

        // Assert
        Assert.Equal("Invalid input! Please enter a single letter.", result);
    }

    [Fact]
    public void AlreadyGuessed_WithPolishLanguage_ReturnsPolishString()
    {
        // Arrange
        var language = Language.Polish;
        var manager = new LocalizationManager(language);

        // Act
        var result = manager.AlreadyGuessed;

        // Assert
        Assert.Equal("Ta litera zosta³a ju¿ u¿yta!", result);
    }

    [Fact]
    public void AlreadyGuessed_WithEnglishLanguage_ReturnsEnglishString()
    {
        // Arrange
        var language = Language.English;
        var manager = new LocalizationManager(language);

        // Act
        var result = manager.AlreadyGuessed;

        // Assert
        Assert.Equal("You already used this letter!", result);
    }

    [Fact]
    public void CorrectGuess_WithPolishLanguage_ReturnsPolishString()
    {
        // Arrange
        var language = Language.Polish;
        var manager = new LocalizationManager(language);

        // Act
        var result = manager.CorrectGuess;

        // Assert
        Assert.Equal("Dobra litera!", result);
    }

    [Fact]
    public void CorrectGuess_WithEnglishLanguage_ReturnsEnglishString()
    {
        // Arrange
        var language = Language.English;
        var manager = new LocalizationManager(language);

        // Act
        var result = manager.CorrectGuess;

        // Assert
        Assert.Equal("Good letter!", result);
    }

    [Fact]
    public void WrongGuess_WithPolishLanguage_ReturnsPolishString()
    {
        // Arrange
        var language = Language.Polish;
        var manager = new LocalizationManager(language);

        // Act
        var result = manager.WrongGuess;

        // Assert
        Assert.Equal("Z³a litera!", result);
    }

    [Fact]
    public void WrongGuess_WithEnglishLanguage_ReturnsEnglishString()
    {
        // Arrange
        var language = Language.English;
        var manager = new LocalizationManager(language);

        // Act
        var result = manager.WrongGuess;

        // Assert
        Assert.Equal("Wrong letter!", result);
    }

    [Fact]
    public void WordProgress_WithPolishLanguage_ReturnsPolishString()
    {
        // Arrange
        var language = Language.Polish;
        var manager = new LocalizationManager(language);

        // Act
        var result = manager.WordProgress;

        // Assert
        Assert.Equal("S³owo: ", result);
    }

    [Fact]
    public void WordProgress_WithEnglishLanguage_ReturnsEnglishString()
    {
        // Arrange
        var language = Language.English;
        var manager = new LocalizationManager(language);

        // Act
        var result = manager.WordProgress;

        // Assert
        Assert.Equal("Word: ", result);
    }

    [Fact]
    public void GuessedLetters_WithPolishLanguage_ReturnsPolishString()
    {
        // Arrange
        var language = Language.Polish;
        var manager = new LocalizationManager(language);

        // Act
        var result = manager.GuessedLetters;

        // Assert
        Assert.Equal("U¿yte litery: ", result);
    }

    [Fact]
    public void GuessedLetters_WithEnglishLanguage_ReturnsEnglishString()
    {
        // Arrange
        var language = Language.English;
        var manager = new LocalizationManager(language);

        // Act
        var result = manager.GuessedLetters;

        // Assert
        Assert.Equal("Used letters: ", result);
    }

    [Fact]
    public void RemainingAttempts_WithPolishLanguage_ReturnsPolishString()
    {
        // Arrange
        var language = Language.Polish;
        var manager = new LocalizationManager(language);

        // Act
        var result = manager.RemainingAttempts;

        // Assert
        Assert.Equal("Pozosta³e próby: ", result);
    }

    [Fact]
    public void RemainingAttempts_WithEnglishLanguage_ReturnsEnglishString()
    {
        // Arrange
        var language = Language.English;
        var manager = new LocalizationManager(language);

        // Act
        var result = manager.RemainingAttempts;

        // Assert
        Assert.Equal("Remaining attempts: ", result);
    }

    [Fact]
    public void YouWon_WithPolishLanguage_ReturnsPolishString()
    {
        // Arrange
        var language = Language.Polish;
        var manager = new LocalizationManager(language);

        // Act
        var result = manager.YouWon;

        // Assert
        Assert.Equal("Gratulacje! Wygra³eœ!", result);
    }

    [Fact]
    public void YouWon_WithEnglishLanguage_ReturnsEnglishString()
    {
        // Arrange
        var language = Language.English;
        var manager = new LocalizationManager(language);

        // Act
        var result = manager.YouWon;

        // Assert
        Assert.Equal("Congratulations! You won!", result);
    }

    [Fact]
    public void YouLost_WithPolishLanguage_ReturnsPolishString()
    {
        // Arrange
        var language = Language.Polish;
        var manager = new LocalizationManager(language);

        // Act
        var result = manager.YouLost;

        // Assert
        Assert.Equal("Przegra³eœ! S³owo to: ", result);
    }

    [Fact]
    public void YouLost_WithEnglishLanguage_ReturnsEnglishString()
    {
        // Arrange
        var language = Language.English;
        var manager = new LocalizationManager(language);

        // Act
        var result = manager.YouLost;

        // Assert
        Assert.Equal("You lost! The word was: ", result);
    }

    [Fact]
    public void PlayAgain_WithPolishLanguage_ReturnsPolishString()
    {
        // Arrange
        var language = Language.Polish;
        var manager = new LocalizationManager(language);

        // Act
        var result = manager.PlayAgain;

        // Assert
        Assert.Equal("Czy chcesz zagraæ jeszcze raz? (T/N): ", result);
    }

    [Fact]
    public void PlayAgain_WithEnglishLanguage_ReturnsEnglishString()
    {
        // Arrange
        var language = Language.English;
        var manager = new LocalizationManager(language);

        // Act
        var result = manager.PlayAgain;

        // Assert
        Assert.Equal("Do you want to play again? (Y/N): ", result);
    }

    [Fact]
    public void InvalidYesNo_WithPolishLanguage_ReturnsPolishString()
    {
        // Arrange
        var language = Language.Polish;
        var manager = new LocalizationManager(language);

        // Act
        var result = manager.InvalidYesNo;

        // Assert
        Assert.Equal("Nieprawid³owa odpowiedŸ! Podaj T lub N.", result);
    }

    [Fact]
    public void InvalidYesNo_WithEnglishLanguage_ReturnsEnglishString()
    {
        // Arrange
        var language = Language.English;
        var manager = new LocalizationManager(language);

        // Act
        var result = manager.InvalidYesNo;

        // Assert
        Assert.Equal("Invalid answer! Please enter Y or N.", result);
    }

    [Fact]
    public void FileNotFound_WithPolishLanguage_ReturnsPolishString()
    {
        // Arrange
        var language = Language.Polish;
        var manager = new LocalizationManager(language);

        // Act
        var result = manager.FileNotFound;

        // Assert
        Assert.Equal("Nie znaleziono pliku ze s³owami: ", result);
    }

    [Fact]
    public void FileNotFound_WithEnglishLanguage_ReturnsEnglishString()
    {
        // Arrange
        var language = Language.English;
        var manager = new LocalizationManager(language);

        // Act
        var result = manager.FileNotFound;

        // Assert
        Assert.Equal("Word file not found: ", result);
    }

    [Fact]
    public void NoWordsAvailable_WithPolishLanguage_ReturnsPolishString()
    {
        // Arrange
        var language = Language.Polish;
        var manager = new LocalizationManager(language);

        // Act
        var result = manager.NoWordsAvailable;

        // Assert
        Assert.Equal("Brak s³ów dla wybranego poziomu trudnoœci!", result);
    }

    [Fact]
    public void NoWordsAvailable_WithEnglishLanguage_ReturnsEnglishString()
    {
        // Arrange
        var language = Language.English;
        var manager = new LocalizationManager(language);

        // Act
        var result = manager.NoWordsAvailable;

        // Assert
        Assert.Equal("No words available for selected difficulty level!", result);
    }

    [Fact]
    public void InvalidMenuChoice_WithPolishLanguage_ReturnsPolishString()
    {
        // Arrange
        var language = Language.Polish;
        var manager = new LocalizationManager(language);

        // Act
        var result = manager.InvalidMenuChoice;

        // Assert
        Assert.Equal("Nieprawid³owy wybór! Wybierz liczbê od 1 do 4.", result);
    }

    [Fact]
    public void InvalidMenuChoice_WithEnglishLanguage_ReturnsEnglishString()
    {
        // Arrange
        var language = Language.English;
        var manager = new LocalizationManager(language);

        // Act
        var result = manager.InvalidMenuChoice;

        // Assert
        Assert.Equal("Invalid choice! Please select a number from 1 to 4.", result);
    }
}

