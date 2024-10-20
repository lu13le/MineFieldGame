

namespace MineFieldGame.Models
{
    public class GameCore
    {
        private const string MovementInstructions = "Use W, A, S, D to move around";

        public GameCore(Field field, Player player)
        {
            Field = field;
            Player = player;
            MoveCount = 0;
        }

        private Field Field { get; }
        private Player Player { get; }
        private int MoveCount { get; set; }

        public void StartGame()
        {
            while (!IsGameOver())
            {
                DisplayGameStatus();
                HandleInput(ReadPlayerInput());
                ProcessPlayerMove();
                MoveCount++;
            }

            EndGame();
        }

        private void DisplayGameStatus()
        {
            Field.DisplayMineField();
            Console.WriteLine($"Lives left: {Player.Lives}");
            Console.WriteLine($"Moves taken: {MoveCount}");
            Console.WriteLine(MovementInstructions);
        }

        private static ConsoleKey ReadPlayerInput() => Console.ReadKey(true).Key;

        private void HandleInput(ConsoleKey input)
        {
            switch (input)
            {
                case ConsoleKey.W:
                    Field.MovePlayerUp();
                    break;
                case ConsoleKey.S:
                    Field.MovePlayerDown();
                    break;
                case ConsoleKey.A:
                    Field.MovePlayerLeft();
                    break;
                case ConsoleKey.D:
                    Field.MovePlayerRight();
                    break;
                default:
                    Console.WriteLine("Invalid input. " + MovementInstructions);
                    break;
            }
        }

        private void ProcessPlayerMove()
        {
            if (!Field.IsMineHit()) return;
            Player.LoseLife();
            Console.WriteLine("Boom! You hit a mine.");
        }

        private bool IsGameOver() =>
            Field.HasPlayerReachedEnd() || Player.Lives <= 0;

        private void EndGame()
        {
            Console.WriteLine(Player.Lives == 0
                ? "Game Over! You ran out of lives."
                : $"Congratulations! You reached the end in {MoveCount} moves.");
        }
    }
}
