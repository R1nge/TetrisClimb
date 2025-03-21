﻿using UnityEngine;

namespace _Assets.Scripts.Configs
{
    public class ConfigProvider : MonoBehaviour
    {
        [SerializeField] private UIConfig uiConfig;

        [SerializeField] private CharacterConfig characterConfig;

        [SerializeField] private GameConfig gameConfig;
        public UIConfig UIConfig => uiConfig;
        public CharacterConfig CharacterConfig => characterConfig;
        public GameConfig GameConfig => gameConfig;
    }
}