using UnityEngine;

namespace _Assets.Scripts.Gameplay.Character.Movement
{
    public class CharacterInput
    {
        public Vector3 GetInput()
        {
            return new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }
    }
}