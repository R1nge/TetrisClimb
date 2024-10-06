using _Assets.Scripts.Configs;
using _Assets.Scripts.Gameplay.Tetris;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Assets.Scripts.Services.Factories
{
    public class TetrisFactory
    {
        private readonly ConfigProvider _configProvider;
        private readonly IObjectResolver _objectResolver;
        private readonly RandomGenerator _randomGenerator;

        private TetrisFactory(IObjectResolver objectResolver, ConfigProvider configProvider,
            RandomGenerator randomGenerator)
        {
            _objectResolver = objectResolver;
            _configProvider = configProvider;
            _randomGenerator = randomGenerator;
        }

        public void CreateRandom(Vector2 position)
        {
            Create(position, _randomGenerator.GetNextTetris());
        }

        private void Create(Vector2 position, TetrisView.TetrisBlockType tetrisBlockType)
        {
            var tetris = _objectResolver.Instantiate(_configProvider.TetrisConfig.GetPrefab(tetrisBlockType), position,
                Quaternion.identity);
            tetris.transform.position = position;
        }
    }
}