using _Assets.Scripts.Configs;
using _Assets.Scripts.Gameplay.Inputs;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Gameplay.Character.Movement
{
    public class CharacterController : MonoBehaviour
    {
        private CharacterMovement _characterMovement;

        [Inject] private ConfigProvider _configProvider;
        [Inject] private InputService _inputService;


        private void Awake() => _characterMovement = new CharacterMovement(_configProvider, transform);

        private void Update() => _characterMovement.Move(_inputService.GetInput(true));
    }
}