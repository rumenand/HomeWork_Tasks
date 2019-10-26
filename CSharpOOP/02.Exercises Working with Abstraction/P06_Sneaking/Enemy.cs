
namespace P06_Sneaking
{
    public class Enemy : Player
    {
        private bool isLeft;
        public bool GetDiection { get => this.isLeft; }

        public Enemy(int xPos, int yPos, bool left)
        {
            this.XPos = xPos;
            this.YPos = yPos;
            this.isLeft = left;
        }

        public void ChangeDirection()
        {
            this.isLeft = !this.isLeft;
        }
    }
}
