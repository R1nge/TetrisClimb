using _Assets.Scripts.Configs;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Gameplay.Tetris
{
    public class TetrisView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [Inject] private ConfigProvider _configProvider;

        public void UpdateView(TetrisBlockType tetrisBlockType)
        {
            spriteRenderer.sprite = _configProvider.TetrisConfig.GetSprite(tetrisBlockType);
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