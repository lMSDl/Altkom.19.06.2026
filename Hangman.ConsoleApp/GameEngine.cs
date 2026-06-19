using Hangman.ConsoleApp.Models;

namespace Hangman.ConsoleApp;

public class GameEngine
{
    private const int MaxWrongGuesses = 6;

    private readonly string _secretWord;
    private readonly HashSet<char> _guessedLetters;
    private int _wrongGuesses;

    public GameState State { get; private set; }
    public int WrongGuesses => _wrongGuesses;
    public int RemainingAttempts => MaxWrongGuesses - _wrongGuesses;
    public HashSet<char> GuessedLetters => _guessedLetters;

    public GameEngine(string secretWord)
    {
        _secretWord = secretWord.ToUpper();
        _guessedLetters = new HashSet<char>();
        _wrongGuesses = 0;
        State = GameState.InProgress;
    }

    public bool ProcessGuess(char letter)
    {
        letter = char.ToUpper(letter);
        _guessedLetters.Add(letter);

        bool isCorrect = _secretWord.Contains(letter);

        if (!isCorrect)
        {
            _wrongGuesses++;
        }

        UpdateGameState();

        return isCorrect;
    }

    public string GetWordProgress()
    {
        return string.Join(" ", _secretWord.Select(c => _guessedLetters.Contains(c) ? c : '_'));
    }

    public string GetSecretWord()
    {
        return _secretWord;
    }

    private void UpdateGameState()
    {
        if (_wrongGuesses >= MaxWrongGuesses)
        {
            State = GameState.Lost;
        }
        else if (_secretWord.All(c => _guessedLetters.Contains(c)))
        {
            State = GameState.Won;
        }
    }
}
