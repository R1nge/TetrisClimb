namespace _Assets.Scripts.Gameplay.Tetris
{
    public class TetrisGridService
    {
        public TetrisData[,] Data = new TetrisData[10, 10];

        public struct TetrisData
        {
            public TetrisBlockType TetrisBlockType;
        }
    }
}