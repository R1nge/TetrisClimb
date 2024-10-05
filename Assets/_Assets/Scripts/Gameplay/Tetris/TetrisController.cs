using _Assets.Scripts.Configs;
using _Assets.Scripts.Gameplay.Inputs;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Gameplay.Tetris
{
    public class TetrisController : MonoBehaviour
    {
        private TetrisMovement _tetrisMovement;

        [Inject] private ConfigProvider _configProvider;
        [Inject] private InputService _inputService;

        private void Awake()
        {
            _tetrisMovement = new TetrisMovement(_configProvider, transform);
        }

        private void Update()
        {
            _tetrisMovement.Move(_inputService.GetInput(false));
        }
    }
}