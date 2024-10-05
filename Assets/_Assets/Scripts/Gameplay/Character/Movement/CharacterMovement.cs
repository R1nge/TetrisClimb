using _Assets.Scripts.Configs;
using UnityEngine;

namespace _Assets.Scripts.Gameplay.Character.Movement
{
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