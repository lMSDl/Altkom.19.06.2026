namespace Hangman.ConsoleApp.Localization;

public static class Strings_pl
{
    // Language selection
    public const string SelectLanguage = "Wybierz język / Select language:";
    public const string LanguagePolish = "1. Polski";
    public const string LanguageEnglish = "2. English";

    // Main menu
    public const string Welcome = "Witaj w grze Wisielec!";
    public const string SelectDifficulty = "Wybierz poziom trudności:";
    public const string DifficultyEasy = "1. Łatwy (3-5 liter)";
    public const string DifficultyMedium = "2. Średni (6-8 liter)";
    public const string DifficultyHard = "3. Trudny (9+ liter)";
    public const string Exit = "4. Wyjście";

    // Game prompts
    public const string EnterLetter = "Podaj literę: ";
    public const string InvalidInput = "Nieprawidłowe dane! Podaj pojedynczą literę.";
    public const string AlreadyGuessed = "Ta litera została już użyta!";
    public const string CorrectGuess = "Dobra litera!";
    public const string WrongGuess = "Zła litera!";

    // Game status
    public const string WordProgress = "Słowo: ";
    public const string GuessedLetters = "Użyte litery: ";
    public const string RemainingAttempts = "Pozostałe próby: ";

    // Win/Loss messages
    public const string YouWon = "Gratulacje! Wygrałeś!";
    public const string YouLost = "Przegrałeś! Słowo to: ";

    // Replay
    public const string PlayAgain = "Czy chcesz zagrać jeszcze raz? (T/N): ";
    public const string InvalidYesNo = "Nieprawidłowa odpowiedź! Podaj T lub N.";

    // Errors
    public const string FileNotFound = "Nie znaleziono pliku ze słowami: ";
    public const string NoWordsAvailable = "Brak słów dla wybranego poziomu trudności!";
    public const string InvalidMenuChoice = "Nieprawidłowy wybór! Wybierz liczbę od 1 do 4.";
}
