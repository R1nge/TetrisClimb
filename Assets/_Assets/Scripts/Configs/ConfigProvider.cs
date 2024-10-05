using UnityEngine;

namespace _Assets.Scripts.Configs
{
    public class ConfigProvider : MonoBehaviour
    {
        [SerializeField] private UIConfig uiConfig;
        public UIConfig UIConfig => uiConfig;
        
        [SerializeField] private CharacterConfig characterConfig;
        public CharacterConfig CharacterConfig => characterConfig;
        
        [SerializeField] private TetrisConfig tetrisConfig;
        public TetrisConfig TetrisConfig => tetrisConfig;
    }
}