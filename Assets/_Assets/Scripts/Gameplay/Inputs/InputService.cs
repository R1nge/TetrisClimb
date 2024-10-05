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
        
        private Vector2 GetCharacterInput()
        {
            return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }

        private Vector2 GetTetrisInput()
        {
            return new Vector2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
        }
    }
}