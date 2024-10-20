using MineFieldGame.Models;
using MineFieldGame.Models.Enums;

namespace MineFieldGameUnitTests
{
    public class FiledClassUnitTests
    {
        [Fact]
        public void Constructor_SetsCorrectDimensions_WhenDifficultyIsEasy()
        {
            var field = new Field(Difficulty.Easy);
            Assert.Equal(5, field.Width);
            Assert.Equal(5, field.Height);
        }

        [Fact]
        public void Constructor_SetsCorrectDimensions_WhenDifficultyIsMedium()
        {
            var field = new Field(Difficulty.Medium);
            Assert.Equal(8, field.Width);
            Assert.Equal(8, field.Height);
        }

        [Fact]
        public void Constructor_SetsCorrectDimensions_WhenDifficultyIsHard()
        {
            var field = new Field(Difficulty.Hard);
            Assert.Equal(12, field.Width);
            Assert.Equal(12, field.Height);
        }

        [Fact]
        public void MovePlayerUp_DoesNotMoveAboveBounds()
        {
            var field = new Field(Difficulty.Easy);
            field.MovePlayerUp(); // Initially at (0, 0)
            Assert.Equal((0, 0), field.PlayerPosition);
        }

        [Fact]
        public void MovePlayerDown_MovesPlayerDownCorrectly()
        {
            var field = new Field(Difficulty.Easy);
            field.MovePlayerDown(); // From (0, 0) to (0, 1)
            Assert.Equal((0, 1), field.PlayerPosition);
        }

        [Fact]
        public void MovePlayerLeft_DoesNotMoveLeftOfBounds()
        {
            var field = new Field(Difficulty.Easy);
            field.MovePlayerLeft(); // Initially at (0, 0)
            Assert.Equal((0, 0), field.PlayerPosition);
        }

        [Fact]
        public void MovePlayerRight_MovesPlayerRightCorrectly()
        {
            var field = new Field(Difficulty.Easy);
            field.MovePlayerRight(); // From (0, 0) to (1, 0)
            Assert.Equal((1, 0), field.PlayerPosition);
        }


        [Fact]
        public void HasPlayerReachedEnd_ReturnsTrue_WhenPlayerIsAtEnd()
        {
            var field = new Field(Difficulty.Easy);
            // Move to (4, 4), which is the bottom right corner for Easy difficulty
            for (int i = 0; i < 4; i++)
            {
                field.MovePlayerRight();
                field.MovePlayerDown();
            }
            Assert.True(field.HasPlayerReachedEnd());
        }

        [Fact]
        public void IsMineHit_ReturnsFalse_WhenNoMineIsHit()
        {
            var field = new Field(Difficulty.Easy);
            field.MovePlayerDown(); // Move to (0, 1)

            // Check if the player is on a cell without a mine.
            Assert.False(field.IsMineHit());
        }

        [Fact]
        public void PlaceMines_DoesNotPlaceMinesInStartingPosition()
        {
            var field = new Field(Difficulty.Easy);
            Assert.False(field.IsMineHit()); // Player starts at (0, 0)
        }

        [Fact]
        public void Constructor_ThrowsException_ForInvalidDifficulty()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Field((Difficulty)999)); // Assuming 999 is invalid
        }

        [Fact]
        public void PlayerStartsAtInitialPosition_0_0()
        {
            var field = new Field(Difficulty.Easy);
            Assert.Equal((0, 0), field.PlayerPosition);
        }
    }
}