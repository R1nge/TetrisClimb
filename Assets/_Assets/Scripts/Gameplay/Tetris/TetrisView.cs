using System;
using _Assets.Scripts.Configs;
using UnityEngine;
using VContainer;
using Random = UnityEngine.Random;

namespace _Assets.Scripts.Gameplay.Tetris
{
    public class TetrisView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private TetrisBlockType tetrisBlockType;
        [Inject] private ConfigProvider _configProvider;

        private void Awake()
        {
            tetrisBlockType = (TetrisBlockType)Random.Range(0, Enum.GetNames(typeof(TetrisBlockType)).Length);
            UpdateView();
        }

        public void UpdateView()
        {
            spriteRenderer.sprite = _configProvider.TetrisConfig.GetPrefab(tetrisBlockType);
        }

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