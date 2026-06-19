using AutoFixture;
using Hangman.ConsoleApp;
using Hangman.ConsoleApp.Models;
using Xunit;

namespace Hangman.UnitTests;

public class GameEngineTests
{
    private readonly Fixture _fixture = new();

    [Fact]
    public void Constructor_WithSecretWord_InitializesProperties()
    {
        // Arrange
        var secretWord = _fixture.Create<string>();

        // Act
        var gameEngine = new GameEngine(secretWord);

        // Assert
        Assert.Equal(0, gameEngine.WrongGuesses);
        Assert.Equal(6, gameEngine.RemainingAttempts);
        Assert.Empty(gameEngine.GuessedLetters);
        Assert.Equal(GameState.InProgress, gameEngine.State);
    }

    [Fact]
    public void Constructor_WithLowercaseSecretWord_ConvertsToUppercase()
    {
        // Arrange
        var secretWord = "lowercase";

        // Act
        var gameEngine = new GameEngine(secretWord);

        // Assert
        Assert.Equal("LOWERCASE", gameEngine.GetSecretWord());
    }

    [Fact]
    public void Constructor_WithMixedCaseSecretWord_ConvertsToUppercase()
    {
        // Arrange
        var secretWord = "MiXeD";

        // Act
        var gameEngine = new GameEngine(secretWord);

        // Assert
        Assert.Equal("MIXED", gameEngine.GetSecretWord());
    }

    [Fact]
    public void WrongGuesses_InitialState_ReturnsZero()
    {
        // Arrange
        var secretWord = _fixture.Create<string>();
        var gameEngine = new GameEngine(secretWord);

        // Act
        var wrongGuesses = gameEngine.WrongGuesses;

        // Assert
        Assert.Equal(0, wrongGuesses);
    }

    [Fact]
    public void WrongGuesses_AfterIncorrectGuess_ReturnsOne()
    {
        // Arrange
        var gameEngine = new GameEngine("WORD");
        gameEngine.ProcessGuess('Z');

        // Act
        var wrongGuesses = gameEngine.WrongGuesses;

        // Assert
        Assert.Equal(1, wrongGuesses);
    }

    [Fact]
    public void WrongGuesses_AfterMultipleIncorrectGuesses_ReturnsCount()
    {
        // Arrange
        var gameEngine = new GameEngine("WORD");
        gameEngine.ProcessGuess('Z');
        gameEngine.ProcessGuess('X');
        gameEngine.ProcessGuess('Q');

        // Act
        var wrongGuesses = gameEngine.WrongGuesses;

        // Assert
        Assert.Equal(3, wrongGuesses);
    }

    [Fact]
    public void WrongGuesses_AfterCorrectGuess_RemainsZero()
    {
        // Arrange
        var gameEngine = new GameEngine("WORD");
        gameEngine.ProcessGuess('W');

        // Act
        var wrongGuesses = gameEngine.WrongGuesses;

        // Assert
        Assert.Equal(0, wrongGuesses);
    }

    [Fact]
    public void RemainingAttempts_InitialState_ReturnsSix()
    {
        // Arrange
        var secretWord = _fixture.Create<string>();
        var gameEngine = new GameEngine(secretWord);

        // Act
        var remainingAttempts = gameEngine.RemainingAttempts;

        // Assert
        Assert.Equal(6, remainingAttempts);
    }

    [Fact]
    public void RemainingAttempts_AfterOneIncorrectGuess_ReturnsFive()
    {
        // Arrange
        var gameEngine = new GameEngine("WORD");
        gameEngine.ProcessGuess('Z');

        // Act
        var remainingAttempts = gameEngine.RemainingAttempts;

        // Assert
        Assert.Equal(5, remainingAttempts);
    }

    [Fact]
    public void RemainingAttempts_AfterMultipleIncorrectGuesses_ReturnsCorrectCount()
    {
        // Arrange
        var gameEngine = new GameEngine("WORD");
        gameEngine.ProcessGuess('Z');
        gameEngine.ProcessGuess('X');
        gameEngine.ProcessGuess('Q');

        // Act
        var remainingAttempts = gameEngine.RemainingAttempts;

        // Assert
        Assert.Equal(3, remainingAttempts);
    }

    [Fact]
    public void RemainingAttempts_AfterCorrectGuess_RemainsSix()
    {
        // Arrange
        var gameEngine = new GameEngine("WORD");
        gameEngine.ProcessGuess('W');

        // Act
        var remainingAttempts = gameEngine.RemainingAttempts;

        // Assert
        Assert.Equal(6, remainingAttempts);
    }

    [Fact]
    public void RemainingAttempts_AfterSixIncorrectGuesses_ReturnsZero()
    {
        // Arrange
        var gameEngine = new GameEngine("WORD");
        gameEngine.ProcessGuess('Z');
        gameEngine.ProcessGuess('X');
        gameEngine.ProcessGuess('Q');
        gameEngine.ProcessGuess('A');
        gameEngine.ProcessGuess('B');
        gameEngine.ProcessGuess('C');

        // Act
        var remainingAttempts = gameEngine.RemainingAttempts;

        // Assert
        Assert.Equal(0, remainingAttempts);
    }

    [Fact]
    public void GuessedLetters_InitialState_ReturnsEmptySet()
    {
        // Arrange
        var secretWord = _fixture.Create<string>();
        var gameEngine = new GameEngine(secretWord);

        // Act
        var guessedLetters = gameEngine.GuessedLetters;

        // Assert
        Assert.Empty(guessedLetters);
    }

    [Fact]
    public void GuessedLetters_AfterOneGuess_ContainsThatLetter()
    {
        // Arrange
        var gameEngine = new GameEngine("WORD");
        gameEngine.ProcessGuess('W');

        // Act
        var guessedLetters = gameEngine.GuessedLetters;

        // Assert
        Assert.Single(guessedLetters);
        Assert.Contains('W', guessedLetters);
    }

    [Fact]
    public void GuessedLetters_AfterMultipleGuesses_ContainsAllLetters()
    {
        // Arrange
        var gameEngine = new GameEngine("WORD");
        gameEngine.ProcessGuess('W');
        gameEngine.ProcessGuess('O');
        gameEngine.ProcessGuess('Z');

        // Act
        var guessedLetters = gameEngine.GuessedLetters;

        // Assert
        Assert.Equal(3, guessedLetters.Count);
        Assert.Contains('W', guessedLetters);
        Assert.Contains('O', guessedLetters);
        Assert.Contains('Z', guessedLetters);
    }

    [Fact]
    public void GuessedLetters_AfterDuplicateGuess_ContainsOnlyUniqueLetters()
    {
        // Arrange
        var gameEngine = new GameEngine("WORD");
        gameEngine.ProcessGuess('W');
        gameEngine.ProcessGuess('W');

        // Act
        var guessedLetters = gameEngine.GuessedLetters;

        // Assert
        Assert.Single(guessedLetters);
        Assert.Contains('W', guessedLetters);
    }

    [Fact]
    public void ProcessGuess_WithCorrectLetter_ReturnsTrue()
    {
        // Arrange
        var gameEngine = new GameEngine("WORD");

        // Act
        var result = gameEngine.ProcessGuess('W');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void ProcessGuess_WithIncorrectLetter_ReturnsFalse()
    {
        // Arrange
        var gameEngine = new GameEngine("WORD");

        // Act
        var result = gameEngine.ProcessGuess('Z');

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void ProcessGuess_WithLowercaseLetter_ConvertsToUppercase()
    {
        // Arrange
        var gameEngine = new GameEngine("WORD");

        // Act
        var result = gameEngine.ProcessGuess('w');

        // Assert
        Assert.True(result);
        Assert.Contains('W', gameEngine.GuessedLetters);
    }

    [Fact]
    public void ProcessGuess_WithCorrectLetter_AddsToGuessedLetters()
    {
        // Arrange
        var gameEngine = new GameEngine("WORD");

        // Act
        gameEngine.ProcessGuess('W');

        // Assert
        Assert.Contains('W', gameEngine.GuessedLetters);
    }

    [Fact]
    public void ProcessGuess_WithIncorrectLetter_AddsToGuessedLetters()
    {
        // Arrange
        var gameEngine = new GameEngine("WORD");

        // Act
        gameEngine.ProcessGuess('Z');

        // Assert
        Assert.Contains('Z', gameEngine.GuessedLetters);
    }

    [Fact]
    public void ProcessGuess_WithIncorrectLetter_IncrementsWrongGuesses()
    {
        // Arrange
        var gameEngine = new GameEngine("WORD");

        // Act
        gameEngine.ProcessGuess('Z');

        // Assert
        Assert.Equal(1, gameEngine.WrongGuesses);
    }

    [Fact]
    public void ProcessGuess_WithCorrectLetter_DoesNotIncrementWrongGuesses()
    {
        // Arrange
        var gameEngine = new GameEngine("WORD");

        // Act
        gameEngine.ProcessGuess('W');

        // Assert
        Assert.Equal(0, gameEngine.WrongGuesses);
    }

    [Fact]
    public void ProcessGuess_WithAllCorrectLetters_SetsStateToWon()
    {
        // Arrange
        var gameEngine = new GameEngine("WORD");

        // Act
        gameEngine.ProcessGuess('W');
        gameEngine.ProcessGuess('O');
        gameEngine.ProcessGuess('R');
        gameEngine.ProcessGuess('D');

        // Assert
        Assert.Equal(GameState.Won, gameEngine.State);
    }

    [Fact]
    public void ProcessGuess_WithSixIncorrectGuesses_SetsStateToLost()
    {
        // Arrange
        var gameEngine = new GameEngine("WORD");

        // Act
        gameEngine.ProcessGuess('Z');
        gameEngine.ProcessGuess('X');
        gameEngine.ProcessGuess('Q');
        gameEngine.ProcessGuess('A');
        gameEngine.ProcessGuess('B');
        gameEngine.ProcessGuess('C');

        // Assert
        Assert.Equal(GameState.Lost, gameEngine.State);
    }

    [Fact]
    public void ProcessGuess_WithMixedGuesses_MaintainsInProgressState()
    {
        // Arrange
        var gameEngine = new GameEngine("WORD");

        // Act
        gameEngine.ProcessGuess('W');
        gameEngine.ProcessGuess('Z');
        gameEngine.ProcessGuess('O');

        // Assert
        Assert.Equal(GameState.InProgress, gameEngine.State);
    }

    [Fact]
    public void ProcessGuess_WithDuplicateCorrectGuess_StillReturnsTrue()
    {
        // Arrange
        var gameEngine = new GameEngine("WORD");
        gameEngine.ProcessGuess('W');

        // Act
        var result = gameEngine.ProcessGuess('W');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void ProcessGuess_WithDuplicateIncorrectGuess_StillReturnsFalse()
    {
        // Arrange
        var gameEngine = new GameEngine("WORD");
        gameEngine.ProcessGuess('Z');

        // Act
        var result = gameEngine.ProcessGuess('Z');

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void ProcessGuess_WithDuplicateIncorrectGuess_IncrementsWrongGuessesAgain()
    {
        // Arrange
        var gameEngine = new GameEngine("WORD");
        gameEngine.ProcessGuess('Z');

        // Act
        gameEngine.ProcessGuess('Z');

        // Assert
        Assert.Equal(2, gameEngine.WrongGuesses);
    }

    [Fact]
    public void GetWordProgress_WithNoGuesses_ReturnsAllUnderscores()
    {
        // Arrange
        var gameEngine = new GameEngine("WORD");

        // Act
        var result = gameEngine.GetWordProgress();

        // Assert
        Assert.Equal("_ _ _ _", result);
    }

    [Fact]
    public void GetWordProgress_WithOneCorrectGuess_RevealsGuessedLetter()
    {
        // Arrange
        var gameEngine = new GameEngine("WORD");
        gameEngine.ProcessGuess('W');

        // Act
        var result = gameEngine.GetWordProgress();

        // Assert
        Assert.Equal("W _ _ _", result);
    }

    [Fact]
    public void GetWordProgress_WithMultipleCorrectGuesses_RevealsGuessedLetters()
    {
        // Arrange
        var gameEngine = new GameEngine("WORD");
        gameEngine.ProcessGuess('W');
        gameEngine.ProcessGuess('O');

        // Act
        var result = gameEngine.GetWordProgress();

        // Assert
        Assert.Equal("W O _ _", result);
    }

    [Fact]
    public void GetWordProgress_WithAllCorrectGuesses_RevealsFullWord()
    {
        // Arrange
        var gameEngine = new GameEngine("WORD");
        gameEngine.ProcessGuess('W');
        gameEngine.ProcessGuess('O');
        gameEngine.ProcessGuess('R');
        gameEngine.ProcessGuess('D');

        // Act
        var result = gameEngine.GetWordProgress();

        // Assert
        Assert.Equal("W O R D", result);
    }

    [Fact]
    public void GetWordProgress_WithIncorrectGuess_StillShowsUnderscores()
    {
        // Arrange
        var gameEngine = new GameEngine("WORD");
        gameEngine.ProcessGuess('Z');

        // Act
        var result = gameEngine.GetWordProgress();

        // Assert
        Assert.Equal("_ _ _ _", result);
    }

    [Fact]
    public void GetWordProgress_WithMixedGuesses_ShowsOnlyCorrectLetters()
    {
        // Arrange
        var gameEngine = new GameEngine("WORD");
        gameEngine.ProcessGuess('W');
        gameEngine.ProcessGuess('Z');
        gameEngine.ProcessGuess('O');

        // Act
        var result = gameEngine.GetWordProgress();

        // Assert
        Assert.Equal("W O _ _", result);
    }

    [Fact]
    public void GetWordProgress_WithRepeatingLetters_RevealsAllOccurrences()
    {
        // Arrange
        var gameEngine = new GameEngine("BANANA");
        gameEngine.ProcessGuess('A');

        // Act
        var result = gameEngine.GetWordProgress();

        // Assert
        Assert.Equal("_ A _ A _ A", result);
    }

    [Fact]
    public void GetWordProgress_WithLowercaseGuess_MatchesUppercaseWord()
    {
        // Arrange
        var gameEngine = new GameEngine("WORD");
        gameEngine.ProcessGuess('w');

        // Act
        var result = gameEngine.GetWordProgress();

        // Assert
        Assert.Equal("W _ _ _", result);
    }

    [Fact]
    public void GetWordProgress_WithSingleLetterWord_ReturnsUnderscoreOrLetter()
    {
        // Arrange
        var gameEngine = new GameEngine("A");

        // Act
        var resultBefore = gameEngine.GetWordProgress();
        gameEngine.ProcessGuess('A');
        var resultAfter = gameEngine.GetWordProgress();

        // Assert
        Assert.Equal("_", resultBefore);
        Assert.Equal("A", resultAfter);
    }

    [Fact]
    public void GetSecretWord_WithAnySecretWord_ReturnsSecretWord()
    {
        // Arrange
        var secretWord = _fixture.Create<string>();
        var gameEngine = new GameEngine(secretWord);

        // Act
        var result = gameEngine.GetSecretWord();

        // Assert
        Assert.Equal(secretWord.ToUpper(), result);
    }

    [Fact]
    public void GetSecretWord_WithLowercaseWord_ReturnsUppercase()
    {
        // Arrange
        var gameEngine = new GameEngine("word");

        // Act
        var result = gameEngine.GetSecretWord();

        // Assert
        Assert.Equal("WORD", result);
    }

    [Fact]
    public void GetSecretWord_AfterGuesses_RemainsUnchanged()
    {
        // Arrange
        var gameEngine = new GameEngine("WORD");
        gameEngine.ProcessGuess('W');
        gameEngine.ProcessGuess('Z');

        // Act
        var result = gameEngine.GetSecretWord();

        // Assert
        Assert.Equal("WORD", result);
    }

    [Fact]
    public void GetSecretWord_WithSpecialCharacters_ReturnsAsIs()
    {
        // Arrange
        var gameEngine = new GameEngine("TEST-WORD");

        // Act
        var result = gameEngine.GetSecretWord();

        // Assert
        Assert.Equal("TEST-WORD", result);
    }

    [Fact]
    public void GetSecretWord_WithNumbers_ReturnsAsIs()
    {
        // Arrange
        var gameEngine = new GameEngine("WORD123");

        // Act
        var result = gameEngine.GetSecretWord();

        // Assert
        Assert.Equal("WORD123", result);
    }
}
