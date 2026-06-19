using Hangman.ConsoleApp.Models;

namespace Hangman.ConsoleApp.Localization;

public class LocalizationManager
{
    private readonly Language _language;

    public LocalizationManager(Language language)
    {
        _language = language;
    }

    public string SelectLanguage => GetString(Strings_pl.SelectLanguage, Strings_en.SelectLanguage);
    public string LanguagePolish => GetString(Strings_pl.LanguagePolish, Strings_en.LanguagePolish);
    public string LanguageEnglish => GetString(Strings_pl.LanguageEnglish, Strings_en.LanguageEnglish);

    public string Welcome => GetString(Strings_pl.Welcome, Strings_en.Welcome);
    public string SelectDifficulty => GetString(Strings_pl.SelectDifficulty, Strings_en.SelectDifficulty);
    public string DifficultyEasy => GetString(Strings_pl.DifficultyEasy, Strings_en.DifficultyEasy);
    public string DifficultyMedium => GetString(Strings_pl.DifficultyMedium, Strings_en.DifficultyMedium);
    public string DifficultyHard => GetString(Strings_pl.DifficultyHard, Strings_en.DifficultyHard);
    public string Exit => GetString(Strings_pl.Exit, Strings_en.Exit);

    public string EnterLetter => GetString(Strings_pl.EnterLetter, Strings_en.EnterLetter);
    public string InvalidInput => GetString(Strings_pl.InvalidInput, Strings_en.InvalidInput);
    public string AlreadyGuessed => GetString(Strings_pl.AlreadyGuessed, Strings_en.AlreadyGuessed);
    public string CorrectGuess => GetString(Strings_pl.CorrectGuess, Strings_en.CorrectGuess);
    public string WrongGuess => GetString(Strings_pl.WrongGuess, Strings_en.WrongGuess);

    public string WordProgress => GetString(Strings_pl.WordProgress, Strings_en.WordProgress);
    public string GuessedLetters => GetString(Strings_pl.GuessedLetters, Strings_en.GuessedLetters);
    public string RemainingAttempts => GetString(Strings_pl.RemainingAttempts, Strings_en.RemainingAttempts);

    public string YouWon => GetString(Strings_pl.YouWon, Strings_en.YouWon);
    public string YouLost => GetString(Strings_pl.YouLost, Strings_en.YouLost);

    public string PlayAgain => GetString(Strings_pl.PlayAgain, Strings_en.PlayAgain);
    public string InvalidYesNo => GetString(Strings_pl.InvalidYesNo, Strings_en.InvalidYesNo);

    public string FileNotFound => GetString(Strings_pl.FileNotFound, Strings_en.FileNotFound);
    public string NoWordsAvailable => GetString(Strings_pl.NoWordsAvailable, Strings_en.NoWordsAvailable);
    public string InvalidMenuChoice => GetString(Strings_pl.InvalidMenuChoice, Strings_en.InvalidMenuChoice);

    private string GetString(string polishText, string englishText)
    {
        return _language == Language.Polish ? polishText : englishText;
    }
}
