using System;
using _Assets.Scripts.Configs;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Gameplay.Character.Movement
{
    public class CharacterController : MonoBehaviour
    {
        private CharacterMovement _characterMovement;
        private CharacterInput _characterInput;

        [Inject] private ConfigProvider _configProvider;


        private void Awake()
        {
            _characterMovement = new CharacterMovement(_configProvider, transform);
            _characterInput = new CharacterInput();
        }

        private void Update()
        {
            _characterMovement.Move(_characterInput.GetInput());
        }
    }
}