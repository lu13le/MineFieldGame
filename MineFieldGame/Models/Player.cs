
namespace MineFieldGame.Models
{
    public class Player
    {
        public int Lives { get; private set; } = 3;
        public void LoseLife() => Lives--;
    }
}
