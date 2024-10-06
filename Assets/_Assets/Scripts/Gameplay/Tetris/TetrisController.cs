using _Assets.Scripts.Configs;
using _Assets.Scripts.Gameplay.Inputs;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Gameplay.Tetris
{
    public class TetrisController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rigidbody2D;

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
            _tetrisMovement = new TetrisMovement(_configProvider, rigidbody2D);
            _tetrisRotation = new TetrisRotation(_configProvider, transform);
        }

        private void Update()
        {
            Move();
            Rotate();
        }


        private void FixedUpdate()
        {
            _tetrisMovement.Move();
            _tetrisMovement.ResetInput();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.transform.TryGetComponent(out TetrisView tetrisView))
            {
                _canMove = false;
                _canRotate = false;
            }

            if (other.transform.TryGetComponent(out GroundView groundView))
            {
                _canMove = false;
                _canRotate = false;
            }
        }

        private void Move()
        {
            if (_canMove)
            {
                Vector3 direction = _inputService.GetMovementInput(false);

                if (direction != Vector3.zero && _moveKeyReleased)
                {
                    _tetrisMovement.SetInput(direction);
                    _moveKeyReleased = false;
                }
                else if (direction == Vector3.zero)
                {
                    _moveKeyReleased = true;
                }
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