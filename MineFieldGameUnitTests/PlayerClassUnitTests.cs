using MineFieldGame.Models;

namespace MineFieldGameUnitTests
{
    public class PlayerTests
    {
        [Fact]
        public void Player_InitialLives_AreThree()
        {
            // Arrange
            var player = new Player();

            // Act
            var initialLives = player.Lives;

            // Assert
            Assert.Equal(3, initialLives);
        }

        [Fact]
        public void LoseLife_DecreasesLivesByOne()
        {
            // Arrange
            var player = new Player();
            var initialLives = player.Lives;

            // Act
            player.LoseLife();
            var livesAfterLose = player.Lives;

            // Assert
            Assert.Equal(initialLives - 1, livesAfterLose);
        }


        [Fact]
        public void LoseLife_OnlyAffectsLives()
        {
            // Arrange
            var player = new Player();
            var initialLives = player.Lives;

            // Act
            player.LoseLife();

            // Assert
            Assert.NotEqual(initialLives, player.Lives); // Lives should have changed
            Assert.Equal(2, player.Lives); // Verify the expected outcome
        }
    }
}
