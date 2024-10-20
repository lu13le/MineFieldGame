using MineFieldGame.Models;
using MineFieldGame.Models.Enums;

DisplayWelcomeMessage();
var difficultyInput = Console.ReadLine();
if (difficultyInput is not null)
{
    var difficulty = ParseDifficulty(difficultyInput);
    var game = new GameCore(new Field(difficulty), new Player());
    game.StartGame();
}

return;

static Difficulty ParseDifficulty(string input)
{
    return input.ToLower() switch
    {
        "easy" => Difficulty.Easy,
        "medium" => Difficulty.Medium,
        "hard" => Difficulty.Hard,
        _ => Difficulty.Medium
    };
}

static void DisplayWelcomeMessage()
{
    Console.WriteLine("Welcome to the Minefield Game! This is where the real fun begins! :)");
    Console.WriteLine("Move around using the following keys:");
    Console.WriteLine("W: Up, S: Down, A: Left, D: Right");
    Console.WriteLine("Please select a difficulty: Easy, Medium, Hard");
}