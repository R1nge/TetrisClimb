using System;
using _Assets.Scripts.Gameplay.Tetris;
using UnityEngine;

namespace _Assets.Scripts.Configs
{
    [CreateAssetMenu(fileName = "TetrisConfig", menuName = "Configs/TetrisConfig", order = 0)]
    public class TetrisConfig : ScriptableObject
    {
        [SerializeField] private TetrisView iPrefab;
        [SerializeField] private TetrisView jPrefab;
        [SerializeField] private TetrisView lPrefab;
        [SerializeField] private TetrisView oPrefab;
        [SerializeField] private TetrisView sPrefab;
        [SerializeField] private TetrisView tPrefab;
        [SerializeField] private TetrisView zPrefab;

        [SerializeField] private int moveDistance;
        [SerializeField] private int rotationAngle = 90;
        public int MoveDistance => moveDistance;
        public int RotationAngle => rotationAngle;

        public TetrisView GetPrefab(TetrisView.TetrisBlockType tetrisBlockType)
        {
            return tetrisBlockType switch
            {
                TetrisView.TetrisBlockType.I => iPrefab,
                TetrisView.TetrisBlockType.J => jPrefab,
                TetrisView.TetrisBlockType.L => lPrefab,
                TetrisView.TetrisBlockType.O => oPrefab,
                TetrisView.TetrisBlockType.S => sPrefab,
                TetrisView.TetrisBlockType.T => tPrefab,
                TetrisView.TetrisBlockType.Z => zPrefab,
                _ => throw new ArgumentOutOfRangeException(nameof(tetrisBlockType), tetrisBlockType, null)
            };
        }
    }
}