using _Assets.Scripts.Configs;
using _Assets.Scripts.Gameplay.Inputs;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Gameplay.Tetris
{
    public class TetrisController : MonoBehaviour
    {
        private bool _canMove = true;
        private bool _canRotate = true;

        [Inject] private ConfigProvider _configProvider;
        [Inject] private InputService _inputService;
        private bool _moveKeyReleased = true;
        private bool _rotationKeyReleased = true;
        private TetrisMovement _tetrisMovement;
        private TetrisRotation _tetrisRotation;

        private void Awake()
        {
            _tetrisMovement = new TetrisMovement(_configProvider, transform);
            _tetrisRotation = new TetrisRotation(_configProvider, transform);
        }

        private void Update()
        {
            Move();
            Rotate();
        }


        private void Move()
        {
            if (_canMove)
            {
                Vector3 direction = _inputService.GetMovementInput(false);

                if (direction != Vector3.zero && _moveKeyReleased)
                {
                    _tetrisMovement.Move(direction);
                    _moveKeyReleased = false;
                }
                else if (direction == Vector3.zero)
                {
                    _moveKeyReleased = true;
                }

                _tetrisMovement.MoveDown();
            }
        }

        private void Rotate()
        {
            if (_canRotate)
            {
                Vector3 direction = _inputService.GetTetrisRotationInput();
                if (direction != Vector3.zero && _rotationKeyReleased)
                {
                    _tetrisRotation.Rotate(direction);
                    _rotationKeyReleased = false;
                }
                else if (direction == Vector3.zero)
                {
                    _rotationKeyReleased = true;
                }
            }
        }
    }
}