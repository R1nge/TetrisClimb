using UnityEngine;

namespace _Assets.Scripts.Configs
{
    [CreateAssetMenu(fileName = "CharacterConfig", menuName = "Configs/CharacterConfig", order = 0)]
    public class CharacterConfig : ScriptableObject
    {
        [SerializeField] private GameObject prefab;
        public GameObject Prefab => prefab;

        [SerializeField] private float speed;
        public float Speed => speed;

        [SerializeField] private float jumpHeight;
        public float JumpHeight => jumpHeight;
    }
}