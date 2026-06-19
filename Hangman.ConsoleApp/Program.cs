using Hangman.ConsoleApp;
using Hangman.ConsoleApp.Localization;
using Hangman.ConsoleApp.Models;

// Language selection
Console.OutputEncoding = System.Text.Encoding.UTF8;
Language selectedLanguage = SelectLanguage();

// Initialize localization
LocalizationManager localization = new LocalizationManager(selectedLanguage);

// Main game loop
bool playAgain = true;
while (playAgain)
{
    try
    {
        // Display welcome and select difficulty
        Console.Clear();
        Console.WriteLine("=================================");
        Console.WriteLine(localization.Welcome);
        Console.WriteLine("=================================");
        Console.WriteLine();

        Difficulty difficulty = SelectDifficulty(localization);

        if (difficulty == (Difficulty)(-1))
        {
            // User selected exit
            break;
        }

        // Initialize game components
        WordManager wordManager = new WordManager(selectedLanguage);
        string secretWord = wordManager.GetRandomWord(difficulty);
        GameEngine gameEngine = new GameEngine(secretWord);
        HangmanDisplay display = new HangmanDisplay(localization);
        InputValidator validator = new InputValidator(selectedLanguage);

        // Game loop
        while (gameEngine.State == GameState.InProgress)
        {
            Console.Clear();
            display.DisplayWelcome();
            display.DisplayHangman(gameEngine.WrongGuesses);
            display.DisplayGameState(
                gameEngine.GetWordProgress(),
                gameEngine.GuessedLetters,
                gameEngine.RemainingAttempts
            );

            Console.Write(localization.EnterLetter);
            string? input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                display.DisplayError(localization.InvalidInput);
                Console.ReadKey();
                continue;
            }

            if (!validator.IsValidLetter(input, out char letter))
            {
                display.DisplayError(localization.InvalidInput);
                Console.ReadKey();
                continue;
            }

            if (validator.IsAlreadyGuessed(letter, gameEngine.GuessedLetters))
            {
                display.DisplayError(localization.AlreadyGuessed);
                Console.ReadKey();
                continue;
            }

            bool isCorrect = gameEngine.ProcessGuess(letter);

            if (gameEngine.State == GameState.InProgress)
            {
                if (isCorrect)
                {
                    display.DisplayCorrectGuess();
                }
                else
                {
                    display.DisplayWrongGuess();
                }
                Console.ReadKey();
            }
        }

        // Display final result
        Console.Clear();
        display.DisplayWelcome();
        display.DisplayHangman(gameEngine.WrongGuesses);

        if (gameEngine.State == GameState.Won)
        {
            display.DisplayWin(gameEngine.GetSecretWord());
        }
        else
        {
            display.DisplayLoss(gameEngine.GetSecretWord());
        }

        // Ask for replay
        playAgain = AskPlayAgain(localization);
    }
    catch (FileNotFoundException ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(localization.FileNotFound + ex.Message);
        Console.ResetColor();
        Console.WriteLine();
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
        break;
    }
    catch (InvalidOperationException ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(ex.Message);
        Console.ResetColor();
        Console.WriteLine();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}

Console.WriteLine();
Console.WriteLine("Thank you for playing! / Dziękujemy za grę!");

Language SelectLanguage()
{
    while (true)
    {
        Console.Clear();
        Console.WriteLine("Wybierz język / Select language:");
        Console.WriteLine("1. Polski");
        Console.WriteLine("2. English");
        Console.Write("> ");

        string? input = Console.ReadLine();

        if (input == "1")
        {
            return Language.Polish;
        }
        else if (input == "2")
        {
            return Language.English;
        }

        Console.WriteLine("Invalid choice! / Nieprawidłowy wybór!");
        Console.ReadKey();
    }
}

Difficulty SelectDifficulty(LocalizationManager loc)
{
    while (true)
    {
        Console.WriteLine(loc.SelectDifficulty);
        Console.WriteLine(loc.DifficultyEasy);
        Console.WriteLine(loc.DifficultyMedium);
        Console.WriteLine(loc.DifficultyHard);
        Console.WriteLine(loc.Exit);
        Console.Write("> ");

        string? input = Console.ReadLine();

        switch (input)
        {
            case "1":
                return Difficulty.Easy;
            case "2":
                return Difficulty.Medium;
            case "3":
                return Difficulty.Hard;
            case "4":
                return (Difficulty)(-1); // Exit signal
            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(loc.InvalidMenuChoice);
                Console.ResetColor();
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("=================================");
                Console.WriteLine(loc.Welcome);
                Console.WriteLine("=================================");
                Console.WriteLine();
                break;
        }
    }
}

bool AskPlayAgain(LocalizationManager loc)
{
    while (true)
    {
        Console.Write(loc.PlayAgain);
        string? input = Console.ReadLine()?.Trim().ToUpper();

        if (input == "T" || input == "Y")
        {
            return true;
        }
        else if (input == "N")
        {
            return false;
        }

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(loc.InvalidYesNo);
        Console.ResetColor();
    }
}
