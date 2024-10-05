using _Assets.Scripts.Configs;
using UnityEngine;

namespace _Assets.Scripts.Gameplay.Tetris
{
    public class TetrisRotation
    {
        private readonly Transform _transform;
        private readonly ConfigProvider _configProvider;

        public TetrisRotation(ConfigProvider configProvider, Transform transform)
        {
            _transform = transform;
            _configProvider = configProvider;
        }
        
        public void Rotate(Vector3 direction) => _transform.Rotate(direction * (_configProvider.TetrisConfig.RotationAngle));
    }
}