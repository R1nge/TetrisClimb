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

    public class CharacterInput
    {
        public Vector3 GetInput()
        {
            return new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }
    }

    public class CharacterMovement
    {
        private readonly ConfigProvider _configProvider;
        private readonly Transform _transform;

        public CharacterMovement(ConfigProvider configProvider, Transform transform)
        {
            _configProvider = configProvider;
            _transform = transform;
        }

        public void Move(Vector3 direction)
        {
            _transform.position += direction * (_configProvider.CharacterConfig.Speed * Time.deltaTime);
        }
    }
}