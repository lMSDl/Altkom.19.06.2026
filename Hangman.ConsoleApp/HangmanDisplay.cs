using Hangman.ConsoleApp.Localization;

namespace Hangman.ConsoleApp;

public class HangmanDisplay
{
    private readonly LocalizationManager _localization;
    private static readonly string[] HangmanStages = new string[]
    {
        // Stage 0 - Empty gallows
        @"
  +---+
  |   |
      |
      |
      |
      |
=========",
        // Stage 1 - Head
        @"
  +---+
  |   |
  O   |
      |
      |
      |
=========",
        // Stage 2 - Body
        @"
  +---+
  |   |
  O   |
  |   |
      |
      |
=========",
        // Stage 3 - Left arm
        @"
  +---+
  |   |
  O   |
 /|   |
      |
      |
=========",
        // Stage 4 - Right arm
        @"
  +---+
  |   |
  O   |
 /|\  |
      |
      |
=========",
        // Stage 5 - Left leg
        @"
  +---+
  |   |
  O   |
 /|\  |
 /    |
      |
=========",
        // Stage 6 - Right leg (game over)
        @"
  +---+
  |   |
  O   |
 /|\  |
 / \  |
      |
========="
    };

    public HangmanDisplay(LocalizationManager localization)
    {
        _localization = localization;
    }

    public void DisplayHangman(int wrongGuesses)
    {
        // Determine colors based on danger level
        ConsoleColor gallowsColor = ConsoleColor.DarkYellow; // Brown-ish color for gallows
        ConsoleColor personColor = wrongGuesses switch
        {
            0 or 1 or 2 => ConsoleColor.Green,      // Safe zone
            3 or 4 => ConsoleColor.Yellow,           // Warning zone
            _ => ConsoleColor.Red                    // Danger zone
        };

        string stage = HangmanStages[wrongGuesses];
        string[] lines = stage.Split('\n');

        foreach (string line in lines)
        {
            if (string.IsNullOrEmpty(line))
                continue;

            // Print each character with appropriate color
            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];

                // Person parts: O (head), / and \ (limbs)
                if (c == 'O' || (c == '/' && i < 4) || (c == '\\' && i < 5))
                {
                    Console.ForegroundColor = personColor;
                    Console.Write(c);
                    Console.ResetColor();
                }
                // Vertical body part (|) when it's the person's body
                else if (c == '|' && i >= 2 && i <= 3 && wrongGuesses >= 2 && line.Trim().StartsWith('|'))
                {
                    Console.ForegroundColor = personColor;
                    Console.Write(c);
                    Console.ResetColor();
                }
                // Gallows structure parts
                else if (c == '+' || c == '-' || c == '=' || (c == '|' && i > 4))
                {
                    Console.ForegroundColor = gallowsColor;
                    Console.Write(c);
                    Console.ResetColor();
                }
                // Rope (vertical bar at position 2)
                else if (c == '|' && i == 2)
                {
                    Console.ForegroundColor = gallowsColor;
                    Console.Write(c);
                    Console.ResetColor();
                }
                // Default (spaces, etc.)
                else
                {
                    Console.Write(c);
                }
            }
            Console.WriteLine();
        }
    }

    public void DisplayGameState(string wordProgress, HashSet<char> guessedLetters, int remainingAttempts)
    {
        Console.WriteLine();

        // Color-code the word progress
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write(_localization.WordProgress);
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(wordProgress);
        Console.ResetColor();

        // Display guessed letters
        Console.Write(_localization.GuessedLetters);
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine(string.Join(", ", guessedLetters.OrderBy(c => c)));
        Console.ResetColor();

        // Color-code remaining attempts based on count
        Console.Write(_localization.RemainingAttempts);
        ConsoleColor attemptsColor = remainingAttempts switch
        {
            >= 4 => ConsoleColor.Green,
            2 or 3 => ConsoleColor.Yellow,
            _ => ConsoleColor.Red
        };
        Console.ForegroundColor = attemptsColor;
        Console.WriteLine(remainingAttempts);
        Console.ResetColor();

        Console.WriteLine();
    }

    public void DisplayWelcome()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("=================================");
        Console.WriteLine(_localization.Welcome);
        Console.WriteLine("=================================");
        Console.ResetColor();
        Console.WriteLine();
    }

    public void DisplayWin(string word)
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("*********************************");
        Console.WriteLine(_localization.YouWon);
        Console.Write(_localization.WordProgress);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(word);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("*********************************");
        Console.ResetColor();
        Console.WriteLine();
    }

    public void DisplayLoss(string word)
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("*********************************");
        Console.Write(_localization.YouLost);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(word);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("*********************************");
        Console.ResetColor();
        Console.WriteLine();
    }

    public void DisplayCorrectGuess()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(_localization.CorrectGuess);
        Console.ResetColor();
    }

    public void DisplayWrongGuess()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(_localization.WrongGuess);
        Console.ResetColor();
    }

    public void DisplayError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}
