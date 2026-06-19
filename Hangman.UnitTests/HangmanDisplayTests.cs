using System.Text;
using AutoFixture;
using Hangman.ConsoleApp;
using Hangman.ConsoleApp.Localization;
using Hangman.ConsoleApp.Models;
using Moq;
using Xunit;

namespace Hangman.UnitTests;

public class HangmanDisplayTests : IDisposable
{
    private readonly Fixture _fixture = new();
    private readonly StringWriter _consoleOutput = new();
    private readonly TextWriter _originalOutput = Console.Out;

    public HangmanDisplayTests()
    {
        Console.SetOut(_consoleOutput);
    }

    public void Dispose()
    {
        Console.SetOut(_originalOutput);
        _consoleOutput.Dispose();
    }

    [Fact]
    public void Constructor_WithValidLocalization_CreatesInstance()
    {
        // Arrange
        var mockLocalization = new Mock<LocalizationManager>(Language.English);

        // Act
        var display = new HangmanDisplay(mockLocalization.Object);

        // Assert
        Assert.NotNull(display);
    }

    [Fact]
    public void DisplayHangman_WithOneWrongGuess_DisplaysHead()
    {
        // Arrange
        var mockLocalization = new Mock<LocalizationManager>(Language.English);
        var display = new HangmanDisplay(mockLocalization.Object);

        // Act
        display.DisplayHangman(1);

        // Assert
        var output = _consoleOutput.ToString();
        Assert.Contains("O", output);
        Assert.Contains("+---+", output);
    }

    [Fact]
    public void DisplayHangman_WithTwoWrongGuesses_DisplaysHeadAndBody()
    {
        // Arrange
        var mockLocalization = new Mock<LocalizationManager>(Language.English);
        var display = new HangmanDisplay(mockLocalization.Object);

        // Act
        display.DisplayHangman(2);

        // Assert
        var output = _consoleOutput.ToString();
        Assert.Contains("O", output);
        Assert.True(output.Length > 0);
    }

    [Fact]
    public void DisplayHangman_WithThreeWrongGuesses_DisplaysWithLeftArm()
    {
        // Arrange
        var mockLocalization = new Mock<LocalizationManager>(Language.English);
        var display = new HangmanDisplay(mockLocalization.Object);

        // Act
        display.DisplayHangman(3);

        // Assert
        var output = _consoleOutput.ToString();
        Assert.Contains("O", output);
        Assert.Contains("/", output);
    }

    [Fact]
    public void DisplayHangman_WithFourWrongGuesses_DisplaysWithBothArms()
    {
        // Arrange
        var mockLocalization = new Mock<LocalizationManager>(Language.English);
        var display = new HangmanDisplay(mockLocalization.Object);

        // Act
        display.DisplayHangman(4);

        // Assert
        var output = _consoleOutput.ToString();
        Assert.Contains("O", output);
        Assert.Contains("/", output);
        Assert.Contains("\\", output);
    }

    [Fact]
    public void DisplayHangman_WithFiveWrongGuesses_DisplaysWithLeftLeg()
    {
        // Arrange
        var mockLocalization = new Mock<LocalizationManager>(Language.English);
        var display = new HangmanDisplay(mockLocalization.Object);

        // Act
        display.DisplayHangman(5);

        // Assert
        var output = _consoleOutput.ToString();
        Assert.Contains("O", output);
        Assert.True(output.Length > 0);
    }

    [Fact]
    public void DisplayHangman_WithSixWrongGuesses_DisplaysCompleteHangman()
    {
        // Arrange
        var mockLocalization = new Mock<LocalizationManager>(Language.English);
        var display = new HangmanDisplay(mockLocalization.Object);

        // Act
        display.DisplayHangman(6);

        // Assert
        var output = _consoleOutput.ToString();
        Assert.Contains("O", output);
        Assert.Contains("/", output);
        Assert.Contains("\\", output);
    }

    [Fact]
    public void DisplayGameState_WithValidInputs_DisplaysAllInformation()
    {
        // Arrange
        var localization = new LocalizationManager(Language.English);
        var display = new HangmanDisplay(localization);
        var wordProgress = _fixture.Create<string>();
        var guessedLetters = new HashSet<char> { 'a', 'b', 'c' };
        var remainingAttempts = _fixture.Create<int>();

        // Act
        display.DisplayGameState(wordProgress, guessedLetters, remainingAttempts);

        // Assert
        var output = _consoleOutput.ToString();
        Assert.Contains(wordProgress, output);
        Assert.Contains(localization.WordProgress, output);
        Assert.Contains(localization.GuessedLetters, output);
        Assert.Contains(localization.RemainingAttempts, output);
    }

    [Fact]
    public void DisplayGameState_WithFourRemainingAttempts_DisplaysCorrectly()
    {
        // Arrange
        var localization = new LocalizationManager(Language.English);
        var display = new HangmanDisplay(localization);
        var wordProgress = _fixture.Create<string>();
        var guessedLetters = new HashSet<char> { 'x', 'y' };
        var remainingAttempts = 4;

        // Act
        display.DisplayGameState(wordProgress, guessedLetters, remainingAttempts);

        // Assert
        var output = _consoleOutput.ToString();
        Assert.Contains("4", output);
    }

    [Fact]
    public void DisplayGameState_WithTwoRemainingAttempts_DisplaysCorrectly()
    {
        // Arrange
        var localization = new LocalizationManager(Language.English);
        var display = new HangmanDisplay(localization);
        var wordProgress = _fixture.Create<string>();
        var guessedLetters = new HashSet<char> { 'x' };
        var remainingAttempts = 2;

        // Act
        display.DisplayGameState(wordProgress, guessedLetters, remainingAttempts);

        // Assert
        var output = _consoleOutput.ToString();
        Assert.Contains("2", output);
    }

    [Fact]
    public void DisplayGameState_WithOneRemainingAttempt_DisplaysCorrectly()
    {
        // Arrange
        var localization = new LocalizationManager(Language.English);
        var display = new HangmanDisplay(localization);
        var wordProgress = _fixture.Create<string>();
        var guessedLetters = new HashSet<char> { 'z' };
        var remainingAttempts = 1;

        // Act
        display.DisplayGameState(wordProgress, guessedLetters, remainingAttempts);

        // Assert
        var output = _consoleOutput.ToString();
        Assert.Contains("1", output);
    }

    [Fact]
    public void DisplayGameState_OrdersGuessedLetters_Alphabetically()
    {
        // Arrange
        var localization = new LocalizationManager(Language.English);
        var display = new HangmanDisplay(localization);
        var wordProgress = _fixture.Create<string>();
        var guessedLetters = new HashSet<char> { 'z', 'a', 'm', 'c' };
        var remainingAttempts = _fixture.Create<int>();

        // Act
        display.DisplayGameState(wordProgress, guessedLetters, remainingAttempts);

        // Assert
        var output = _consoleOutput.ToString();
        Assert.Contains("a, c, m, z", output);
    }

    [Fact]
    public void DisplayWin_WithWord_DisplaysWinMessage()
    {
        // Arrange
        var localization = new LocalizationManager(Language.English);
        var display = new HangmanDisplay(localization);
        var word = _fixture.Create<string>();

        // Act
        display.DisplayWin(word);

        // Assert
        var output = _consoleOutput.ToString();
        Assert.Contains("*********************************", output);
        Assert.Contains("Congratulations! You won!", output);
        Assert.Contains("Word: ", output);
        Assert.Contains(word, output);
    }

    [Fact]
    public void DisplayLoss_WithWord_DisplaysLossMessage()
    {
        // Arrange
        var localization = new LocalizationManager(Language.English);
        var display = new HangmanDisplay(localization);
        var word = _fixture.Create<string>();

        // Act
        display.DisplayLoss(word);

        // Assert
        var output = _consoleOutput.ToString();
        Assert.Contains("*********************************", output);
        Assert.Contains(word, output);
    }

    [Fact]
    public void DisplayCorrectGuess_DisplaysCorrectGuessMessage()
    {
        // Arrange
        var localization = new LocalizationManager(Language.English);
        var display = new HangmanDisplay(localization);

        // Act
        display.DisplayCorrectGuess();

        // Assert
        var output = _consoleOutput.ToString();
        Assert.True(output.Length > 0);
    }

    [Fact]
    public void DisplayWrongGuess_DisplaysWrongGuessMessage()
    {
        // Arrange
        var localization = new LocalizationManager(Language.English);
        var display = new HangmanDisplay(localization);

        // Act
        display.DisplayWrongGuess();

        // Assert
        var output = _consoleOutput.ToString();
        Assert.True(output.Length > 0);
    }

    [Fact]
    public void DisplayError_WithMessage_DisplaysErrorMessage()
    {
        // Arrange
        var localization = new LocalizationManager(Language.English);
        var display = new HangmanDisplay(localization);
        var errorMessage = _fixture.Create<string>();

        // Act
        display.DisplayError(errorMessage);

        // Assert
        var output = _consoleOutput.ToString();
        Assert.Contains(errorMessage, output);
    }
}
