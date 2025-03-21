using _Assets.Scripts.Configs;
using _Assets.Scripts.Gameplay.Inputs;
using _Assets.Scripts.Gameplay.Tetris;
using _Assets.Scripts.Services.StateMachine;
using _Assets.Scripts.Services.UIs.StateMachine;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Assets.Scripts.CompositionRoot
{
    public class RootInstaller : LifetimeScope
    {
        [SerializeField] private ConfigProvider configProvider;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<InputService>(Lifetime.Singleton);
            builder.Register<RandomGenerator>(Lifetime.Singleton);

            builder.RegisterComponent(configProvider);
            builder.Register<SceneSerivce>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();

            builder.Register<UIStateMachine>(Lifetime.Singleton);
            builder.Register<GameStateMachine>(Lifetime.Singleton);
        }
    }
}