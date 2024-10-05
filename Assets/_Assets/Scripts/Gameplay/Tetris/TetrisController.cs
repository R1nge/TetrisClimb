using _Assets.Scripts.Configs;
using _Assets.Scripts.Gameplay.Inputs;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Gameplay.Tetris
{
    public class TetrisController : MonoBehaviour
    {
        private TetrisMovement _tetrisMovement;
        private TetrisRotation _tetrisRotation;

        private bool _canMove = true;
        private bool _canRotate = true;
        private bool _rotationKeyReleased = true;

        [Inject] private ConfigProvider _configProvider;
        [Inject] private InputService _inputService;

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
                _tetrisMovement.Move(_inputService.GetMovementInput(false));
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