using MineFieldGame.Models.Enums;
using MineFieldGame.Models;

namespace MineFieldGameUnitTests
{
    public class GameCoreClassUnitTests
    {

        [Fact]
        public void IsGameOver_ReturnsTrue_WhenPlayerRunsOutOfLives()
        {
            // Arrange
            var field = new Field(Difficulty.Easy);
            var player = new Player();
            var game = new GameCore(field, player);

            // Act
            player.LoseLife(); 
            player.LoseLife(); 
            player.LoseLife(); 

            // Assert
            Assert.True(game.IsGameOver()); // Game should be over since the player has no lives left
        }

        [Fact]
        public void IsGameOver_ReturnsTrue_WhenPlayerReachesEnd()
        {
            // Arrange
            var field = new Field(Difficulty.Easy);
            var player = new Player();
            var game = new GameCore(field, player);

            // Act
            field.PlayerPosition = (4, 4); // Manually set the player to the end position (Width - 1, Height - 1)

            // Assert
            Assert.True(game.IsGameOver()); // Game should be over since the player reached the end
        }

        [Fact]
        public void ProcessPlayerMove_PlayerLosesOneLifeAfterHittingMine()
        {
            // Arrange
            var field = new Field(Difficulty.Easy);
            var player = new Player();
            var game = new GameCore(field, player);

            // Place mine at (0, 0) - the player's starting position
            field.Mines[0, 0] = true;

            using var sw = new StringWriter();
            using var sr = new StringReader(string.Empty);
            Console.SetOut(sw);
            Console.SetIn(sr);

            // Act
            game.ProcessPlayerMove();

            // Assert
            Assert.Equal(2, player.Lives); // Player should lose one life after hitting a mine
            var output = sw.ToString();
            Assert.Contains("Boom! You hit a mine.", output); // Verify mine hit message
        }
    }
}
