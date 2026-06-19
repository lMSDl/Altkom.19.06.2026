using Hangman.ConsoleApp.Models;

namespace Hangman.ConsoleApp;

public class WordManager
{
    private readonly List<string> _words;
    private readonly Random _random;

    public WordManager(Language language)
    {
        _random = new Random();
        _words = LoadWords(language);
    }

    private List<string> LoadWords(Language language)
    {
        string fileName = language == Language.Polish ? "words_pl.txt" : "words_en.txt";
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string filePath = Path.Combine(baseDirectory, "Words", fileName);

        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"Word file not found: {filePath}");
        }

        return File.ReadAllLines(filePath)
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .Select(line => line.Trim().ToUpper())
            .ToList();
    }

    public string GetRandomWord(Difficulty difficulty)
    {
        var filteredWords = FilterWordsByDifficulty(difficulty);

        if (filteredWords.Count == 0)
        {
            throw new InvalidOperationException("No words available for selected difficulty level.");
        }

        int index = _random.Next(filteredWords.Count);
        return filteredWords[index];
    }

    private List<string> FilterWordsByDifficulty(Difficulty difficulty)
    {
        return difficulty switch
        {
            Difficulty.Easy => _words.Where(w => w.Length >= 3 && w.Length <= 5).ToList(),
            Difficulty.Medium => _words.Where(w => w.Length >= 6 && w.Length <= 8).ToList(),
            Difficulty.Hard => _words.Where(w => w.Length >= 9).ToList(),
            _ => new List<string>()
        };
    }
}
