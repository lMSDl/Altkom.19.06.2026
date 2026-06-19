namespace Hangman.ConsoleApp.Localization;

public static class Strings_en
{
    // Language selection
    public const string SelectLanguage = "Wybierz język / Select language:";
    public const string LanguagePolish = "1. Polski";
    public const string LanguageEnglish = "2. English";

    // Main menu
    public const string Welcome = "Welcome to Hangman!";
    public const string SelectDifficulty = "Select difficulty level:";
    public const string DifficultyEasy = "1. Easy (3-5 letters)";
    public const string DifficultyMedium = "2. Medium (6-8 letters)";
    public const string DifficultyHard = "3. Hard (9+ letters)";
    public const string Exit = "4. Exit";

    // Game prompts
    public const string EnterLetter = "Enter a letter: ";
    public const string InvalidInput = "Invalid input! Please enter a single letter.";
    public const string AlreadyGuessed = "You already used this letter!";
    public const string CorrectGuess = "Good letter!";
    public const string WrongGuess = "Wrong letter!";

    // Game status
    public const string WordProgress = "Word: ";
    public const string GuessedLetters = "Used letters: ";
    public const string RemainingAttempts = "Remaining attempts: ";

    // Win/Loss messages
    public const string YouWon = "Congratulations! You won!";
    public const string YouLost = "You lost! The word was: ";

    // Replay
    public const string PlayAgain = "Do you want to play again? (Y/N): ";
    public const string InvalidYesNo = "Invalid answer! Please enter Y or N.";

    // Errors
    public const string FileNotFound = "Word file not found: ";
    public const string NoWordsAvailable = "No words available for selected difficulty level!";
    public const string InvalidMenuChoice = "Invalid choice! Please select a number from 1 to 4.";
}
