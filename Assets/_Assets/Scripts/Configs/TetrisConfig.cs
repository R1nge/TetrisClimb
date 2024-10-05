using System;
using _Assets.Scripts.Gameplay.Tetris;
using UnityEngine;

namespace _Assets.Scripts.Configs
{
    [CreateAssetMenu(fileName = "TetrisConfig", menuName = "Configs/TetrisConfig", order = 0)]
    public class TetrisConfig : ScriptableObject
    {
        [SerializeField] private TetrisView prefab;

        [SerializeField] private int moveDistance;

        [SerializeField] private int rotationAngle = 90;
        [SerializeField] private Sprite i;
        [SerializeField] private Sprite j;
        [SerializeField] private Sprite l;
        [SerializeField] private Sprite o;
        [SerializeField] private Sprite s;
        [SerializeField] private Sprite t;
        [SerializeField] private Sprite z;
        public int MoveDistance => moveDistance;
        public int RotationAngle => rotationAngle;
        public TetrisView Prefab => prefab;

        public Sprite GetSprite(TetrisView.TetrisBlockType tetrisBlockType)
        {
            return tetrisBlockType switch
            {
                TetrisView.TetrisBlockType.I => i,
                TetrisView.TetrisBlockType.J => j,
                TetrisView.TetrisBlockType.L => l,
                TetrisView.TetrisBlockType.O => o,
                TetrisView.TetrisBlockType.S => s,
                TetrisView.TetrisBlockType.T => t,
                TetrisView.TetrisBlockType.Z => z,
                _ => throw new ArgumentOutOfRangeException(nameof(tetrisBlockType), tetrisBlockType, null)
            };
        }
    }
}