using UnityEngine;

namespace _Assets.Scripts.Gameplay.Inputs
{
    public class InputService
    {
        public Vector2 GetMovementInput(bool isCharacter = true)
        {
            if (isCharacter)
            {
                return GetCharacterMovementInput();
            }

            return GetTetrisMovementInput();
        }

        private Vector2 GetTetrisMovementInput()
        {
            if (Input.GetKey(KeyCode.A))
                return new Vector2(-1, 0);
            if (Input.GetKey(KeyCode.D))
                return new Vector2(1, 0);
            if (Input.GetKey(KeyCode.S))
                return new Vector2(0, -1);

            return Vector2.zero;
        }

        public Vector3 GetTetrisRotationInput()
        {
            if (Input.GetKey(KeyCode.Q))
                return new Vector3(0, 0,-1);
            if (Input.GetKey(KeyCode.E))
                return new Vector3(0, 0, 1);

            return Vector3.zero;
        }

        private Vector2 GetCharacterMovementInput()
        {
            if (Input.GetKey(KeyCode.LeftArrow))
                return new Vector2(-1, 0);
            if (Input.GetKey(KeyCode.RightArrow))
                return new Vector2(1, 0);

            return Vector2.zero;
        }
    }
}