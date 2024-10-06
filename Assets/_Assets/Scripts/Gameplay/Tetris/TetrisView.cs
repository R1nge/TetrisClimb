using UnityEngine;

namespace _Assets.Scripts.Gameplay.Tetris
{
    public class TetrisView : MonoBehaviour
    {
        public enum TetrisBlockType : byte
        {
            I = 0,
            J = 1,
            L = 2,
            O = 3,
            S = 4,
            T = 5,
            Z = 6
        }
    }
}