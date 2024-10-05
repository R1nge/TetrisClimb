using _Assets.Scripts.Configs;
using UnityEngine;

namespace _Assets.Scripts.Gameplay.Tetris
{
    public class TetrisMovement
    {
        private readonly Transform _transform;
        private readonly ConfigProvider _configProvider;
        private readonly Vector3 _direction = new Vector2(0, -1);

        public TetrisMovement(ConfigProvider configProvider, Transform transform)
        {
            _transform = transform;
            _configProvider = configProvider;
        }

        public void Move(Vector3 direction)
        {
            _transform.position += (_direction + direction) * (_configProvider.TetrisConfig.Speed * Time.deltaTime);
        } 
    }
}