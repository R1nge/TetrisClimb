using _Assets.Scripts.Configs;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Assets.Scripts.Services.Factories
{
    public class PlayerFactory
    {
        private readonly IObjectResolver _objectResolver;
        private readonly ConfigProvider _configProvider;

        private PlayerFactory(IObjectResolver objectResolver, ConfigProvider configProvider)
        {
            _objectResolver = objectResolver;
            _configProvider = configProvider;
        }

        public GameObject Create(Vector3 position)
        {
            return _objectResolver.Instantiate(_configProvider.CharacterConfig.Prefab, position, Quaternion.identity);
        }
    }
}