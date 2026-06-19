using Hangman.ConsoleApp.Models;

namespace Hangman.ConsoleApp;

public class InputValidator
{
    private readonly Language _language;
    private readonly HashSet<char> _polishLetters;

    public InputValidator(Language language)
    {
        _language = language;
        _polishLetters = new HashSet<char> 
        { 
            'A', 'Ą', 'B', 'C', 'Ć', 'D', 'E', 'Ę', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'Ł', 
            'M', 'N', 'Ń', 'O', 'Ó', 'P', 'Q', 'R', 'S', 'Ś', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'Ź', 'Ż'
        };
    }

    public bool IsValidLetter(string input, out char letter)
    {
        letter = '\0';

        if (string.IsNullOrWhiteSpace(input) || input.Length != 1)
        {
            return false;
        }

        letter = char.ToUpper(input[0]);

        if (_language == Language.Polish)
        {
            return _polishLetters.Contains(letter);
        }
        else
        {
            return char.IsLetter(letter) && letter >= 'A' && letter <= 'Z';
        }
    }

    public bool IsAlreadyGuessed(char letter, HashSet<char> guessedLetters)
    {
        return guessedLetters.Contains(letter);
    }
}
