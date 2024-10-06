using _Assets.Scripts.Configs;
using UnityEngine;

namespace _Assets.Scripts.Gameplay.Tetris
{
    public class TetrisMovement
    {
        private readonly ConfigProvider _configProvider;
        private readonly Vector2 _direction = new Vector2(0, -1);
        private readonly Rigidbody2D _rigidbody2D;
        private Vector2 _input;

        public TetrisMovement(ConfigProvider configProvider, Rigidbody2D rigidbody2D)
        {
            _rigidbody2D = rigidbody2D;
            _configProvider = configProvider;
        }

        public void SetInput(Vector2 direction) => _input = direction;

        public void ResetInput() => _input = Vector2.zero;

        public void Move() =>
            _rigidbody2D.MovePosition(_rigidbody2D.position +
                                      (_direction * _configProvider.GameConfig.Gravity +
                                       _input * _configProvider.TetrisConfig.MoveDistance) * Time.deltaTime);
    }
}