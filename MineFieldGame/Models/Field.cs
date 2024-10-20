using MineFieldGame.Models.Enums;

namespace MineFieldGame.Models
{
    public class Field
    {
        private const char PlayerSymbol = 'P';
        private const char DefaultCellSymbol = '.';

        public Field(Difficulty difficulty)
        {
            (Width, Height, var numberOfMines) = GetFieldDimensions(difficulty);
            Mines = new bool[Width, Height];
            InitializePlayerStartingPosition();
            PlaceMines(numberOfMines);
        }

        public int Width { get; }
        public int Height { get; }
        private bool[,] Mines { get; }
        public (int X, int Y) PlayerPosition { get; set; }

        public void MovePlayerUp() => PlayerPosition = (PlayerPosition.X, Math.Max(0, PlayerPosition.Y - 1));
        public void MovePlayerDown() => PlayerPosition = (PlayerPosition.X, Math.Min(Height - 1, PlayerPosition.Y + 1));
        public void MovePlayerLeft() => PlayerPosition = (Math.Max(0, PlayerPosition.X - 1), PlayerPosition.Y);
        public void MovePlayerRight() => PlayerPosition = (Math.Min(Width - 1, PlayerPosition.X + 1), PlayerPosition.Y);

        public bool IsMineHit() => Mines[PlayerPosition.X, PlayerPosition.Y];

        public bool HasPlayerReachedEnd() =>
            PlayerPosition.X == Width - 1 && PlayerPosition.Y == Height - 1;

        public void DisplayMineField()
        {
            for (var y = 0; y < Height; y++)
            {
                for (var x = 0; x < Width; x++)
                {
                    Console.Write(x == PlayerPosition.X && y == PlayerPosition.Y ? $"{PlayerSymbol} " : $"{DefaultCellSymbol} ");
                }
                Console.WriteLine();
            }
        }

        private static (int Width, int Height, int MineCount) GetFieldDimensions(Difficulty difficulty) => difficulty switch
        {
            Difficulty.Easy => (5, 5, 5),
            Difficulty.Medium => (8, 8, 12),
            Difficulty.Hard => (12, 12, 30),
            _ => throw new ArgumentOutOfRangeException(nameof(difficulty), "Invalid difficulty level.")
        };

        public void PlaceMines(int mineCount)
        {
            var rand = new Random();
            for (var i = 0; i < mineCount; i++)
            {
                int x, y;
                do
                {
                    x = rand.Next(Width);
                    y = rand.Next(Height);
                } while (Mines[x, y]);

                Mines[x, y] = true;
            }
        }

        private void InitializePlayerStartingPosition() => PlayerPosition = (0, 0);
    }
}
