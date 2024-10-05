using _Assets.Scripts.Gameplay.Inputs;
using _Assets.Scripts.Services.Factories;
using _Assets.Scripts.Services.StateMachine;
using _Assets.Scripts.Services.StateMachine.StatesCreators;
using _Assets.Scripts.Services.UIs;
using _Assets.Scripts.Services.UIs.StateMachine;
using _Assets.Scripts.Services.UIs.StatesCreators;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Assets.Scripts.CompositionRoot
{
    public class MainSceneInstaller : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            //TODO: move to the game scene installer
            builder.Register<PlayerFactory>(Lifetime.Singleton);
            builder.Register<TetrisFactory>(Lifetime.Singleton);
            //
            
            builder.Register<MainMenuUIStatesFactory>(Lifetime.Singleton);
            builder.Register<MainMenuUIFactory>(Lifetime.Singleton);
            builder.Register<MainMenuStatesFactory>(Lifetime.Singleton);

            builder.Register<UIMainSceneStateCreator>(Lifetime.Singleton);
            builder.Register<MainSceneStateCreator>(Lifetime.Singleton);
        }
    }
}