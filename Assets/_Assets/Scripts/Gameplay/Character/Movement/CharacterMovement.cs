using _Assets.Scripts.Configs;
using UnityEngine;

namespace _Assets.Scripts.Gameplay.Character.Movement
{
    public class CharacterMovement
    {
        private readonly ConfigProvider _configProvider;
        private readonly Rigidbody2D _rigidbody2D;

        public CharacterMovement(ConfigProvider configProvider, Rigidbody2D rigidbody2D)
        {
            _configProvider = configProvider;
            _rigidbody2D = rigidbody2D;
        }

        public void Move(Vector2 direction) => _rigidbody2D.MovePosition(_rigidbody2D.position +
                                                                         direction * (_configProvider.CharacterConfig
                                                                             .Speed * Time.deltaTime));
    }
}