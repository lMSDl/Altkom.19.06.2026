using AutoFixture;
using Hangman.ConsoleApp;
using Hangman.ConsoleApp.Models;
using Xunit;

namespace Hangman.UnitTests;

public class WordManagerTests
{
    private readonly Fixture _fixture;

    public WordManagerTests()
    {
        _fixture = new Fixture();
    }

    [Fact]
    public void Constructor_WithPolishLanguage_CreatesInstance()
    {
        // Arrange
        var language = Language.Polish;

        // Act
        var wordManager = new WordManager(language);

        // Assert
        Assert.NotNull(wordManager);
    }

    [Fact]
    public void Constructor_WithEnglishLanguage_CreatesInstance()
    {
        // Arrange
        var language = Language.English;

        // Act
        var wordManager = new WordManager(language);

        // Assert
        Assert.NotNull(wordManager);
    }

    [Fact]
    public void GetRandomWord_WithEasyDifficulty_ReturnsWord()
    {
        // Arrange
        var language = Language.Polish;
        var wordManager = new WordManager(language);
        var difficulty = Difficulty.Easy;

        // Act
        var word = wordManager.GetRandomWord(difficulty);

        // Assert
        Assert.NotNull(word);
        Assert.True(word.Length >= 3 && word.Length <= 5);
    }

    [Fact]
    public void GetRandomWord_WithMediumDifficulty_ReturnsWord()
    {
        // Arrange
        var language = Language.Polish;
        var wordManager = new WordManager(language);
        var difficulty = Difficulty.Medium;

        // Act
        var word = wordManager.GetRandomWord(difficulty);

        // Assert
        Assert.NotNull(word);
        Assert.True(word.Length >= 6 && word.Length <= 8);
    }

    [Fact]
    public void GetRandomWord_WithHardDifficulty_ReturnsWord()
    {
        // Arrange
        var language = Language.Polish;
        var wordManager = new WordManager(language);
        var difficulty = Difficulty.Hard;

        // Act
        var word = wordManager.GetRandomWord(difficulty);

        // Assert
        Assert.NotNull(word);
        Assert.True(word.Length >= 9);
    }

    [Fact]
    public void GetRandomWord_WithInvalidDifficulty_ThrowsInvalidOperationException()
    {
        // Arrange
        var language = Language.Polish;
        var wordManager = new WordManager(language);
        var difficulty = (Difficulty)999;

        // Act & Assert
        var exception = Assert.Throws<InvalidOperationException>(() => wordManager.GetRandomWord(difficulty));
        Assert.NotNull(exception);
    }

    [Fact]
    public void GetRandomWord_CalledMultipleTimes_ReturnsDifferentWordsEventually()
    {
        // Arrange
        var language = Language.Polish;
        var wordManager = new WordManager(language);
        var difficulty = Difficulty.Medium;
        var words = new HashSet<string>();
        var iterations = 20;

        // Act
        for (int i = 0; i < iterations; i++)
        {
            words.Add(wordManager.GetRandomWord(difficulty));
        }

        // Assert
        Assert.True(words.Count > 1, "Should return different words when called multiple times");
    }

    [Fact]
    public void GetRandomWord_ReturnsUpperCaseWord()
    {
        // Arrange
        var language = Language.Polish;
        var wordManager = new WordManager(language);
        var difficulty = Difficulty.Easy;

        // Act
        var word = wordManager.GetRandomWord(difficulty);

        // Assert
        Assert.Equal(word, word.ToUpper());
    }
}
