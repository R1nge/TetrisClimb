using UnityEngine;

namespace _Assets.Scripts.Gameplay.Inputs
{
    public class InputService
    {
        public Vector2 GetInput(bool isCharacter = true)
        {
            if (isCharacter)
            {
                return GetCharacterInput();
            }

            return GetTetrisInput();
        }
        
        private Vector2 GetCharacterInput() => new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        private Vector2 GetTetrisInput() => new(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
    }
}